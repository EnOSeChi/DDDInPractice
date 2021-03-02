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
        public void Test()
        {
            using (var ctx = ContextFactory.DefaultContext())
            {
                ctx.Database.EnsureCreated();
                var snackMachine = new SnackMachine();
                snackMachine.InsertMoney(Money.OneCent);
                snackMachine.BuySnack();

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
            snackMachine.InsertMoney(Money.OneCent);
            snackMachine.BuySnack();

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
