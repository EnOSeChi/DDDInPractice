using DDDInPractice.Application;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DDDInPractice.Logic.Tests
{
    public class TemporaryTests
    {
        [Fact]
        public void Test3()
        {
            SnackMachine snackMachine;
            using (var ctx = ContextFactory.DefaultContext())
            {

                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                snackMachine = new SnackMachine();
                snackMachine.LoadSnack(1, new SnackPile(new Snack("Chips"), 10, 0.01m));
                snackMachine.InsertMoney(Money.OneCent);
                snackMachine.BuySnack(1);

                ctx.SnackMachines.Add(snackMachine);
                ctx.SaveChanges();
            }

            var repository = new SnackMachineRepository();
            var snackMachine2 = repository.GetById(snackMachine.Id);
        }

        [Fact]
        public void Test()
        {
            using (var ctx = ContextFactory.DefaultContext())
            {
                ctx.Database.EnsureCreated();
                var snackMachine = new SnackMachine();
                snackMachine.LoadSnack(1, new SnackPile(new Snack("Chips"), 10, 0.01m));
                snackMachine.InsertMoney(Money.OneCent);
                snackMachine.BuySnack(1);

                ctx.SnackMachines.Add(snackMachine);
                ctx.SaveChanges();
            }

            using (var ctx = ContextFactory.DefaultContext())
            {
                try
                {
                    var snackMachine = ctx.SnackMachines.FirstOrDefault();
                    snackMachine.Should().NotBeNull();
                }
                finally
                {
                    ctx.Database.EnsureDeleted();
                }
            }
        }

        [Fact]
        public void Test2()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadSnack(1, new SnackPile(new Snack("Chips"), 10, 0.01m));
            snackMachine.InsertMoney(Money.OneCent);
            snackMachine.BuySnack(1);

            using (var ctx = ContextFactory.DefaultContext())
            {
                ctx.Database.EnsureCreated();
                ctx.SnackMachines.Add(snackMachine);
                ctx.SaveChanges();
            }

            var viewModel = new SnackMachineViewModel(snackMachine);
            viewModel.InsertMoney(Money.OneDollar);
            viewModel.BuySnack();

            using (var ctx = ContextFactory.DefaultContext())
            {
                try
                {
                    var result = ctx.SnackMachines.FirstOrDefault();
                    result.Should().NotBeNull();
                    result.MoneyInside.Amount.Should().Be(1.01m);
                }
                finally
                {
                    ctx.Database.EnsureDeleted();
                }
            }
        }
    }
}
