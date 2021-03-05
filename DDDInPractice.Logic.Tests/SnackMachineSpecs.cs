using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DDDInPractice.Logic.Tests
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void Return_money_empies_money_in_transaction()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Money.OneDollar);

            snackMachine.ReturnMoney();

            snackMachine.MoneyInTransaction.Should().Be(0m);
        }

        [Fact]
        public void Inserted_money_goes_to_money_in_transaction()
        {
            var snackMachine = new SnackMachine();

            snackMachine.InsertMoney(Money.OneCent);
            snackMachine.InsertMoney(Money.OneDollar);

            snackMachine.MoneyInTransaction.Should().Be(1.01m);
        }

        [Fact]
        public void Cannot_insert_more_than_one_coin_or_note_at_a_time()
        {
            var snackMachine = new SnackMachine();
            var twoCent = Money.OneCent + Money.OneCent;

            Action action = () => snackMachine.InsertMoney(twoCent);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void BuySnack_trades_inserted_money_for_a_snack()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadSnack(1, new SnackPile(new Snack("Some snack"), 10, 1m));
            snackMachine.InsertMoney(Money.OneDollar);

            snackMachine.BuySnack(1);

            snackMachine.MoneyInTransaction.Should().Be(0);
            snackMachine.MoneyInside.Amount.Should().Be(1m);
            snackMachine.GetSnackPile(1).Quantity.Should().Be(9);
        }

        [Fact]
        public void Cannot_make_purchase_when_there_is_no_snacks()
        {
            var snackMachine = new SnackMachine();

            Action action = () => snackMachine.BuySnack(1);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Cannot_make_purchase_when_if_not_enough_money_inserted()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadSnack(1, new SnackPile(new Snack("Some snack"), 1, 2m));
            snackMachine.InsertMoney(Money.OneDollar);

            Action action = () => snackMachine.BuySnack(1);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Returns_money_with_highest_denomination_first()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadMoney(Money.OneDollar);

            snackMachine.InsertMoney(Money.Quarter);
            snackMachine.InsertMoney(Money.Quarter);
            snackMachine.InsertMoney(Money.Quarter);
            snackMachine.InsertMoney(Money.Quarter);

            snackMachine.ReturnMoney();

            snackMachine.MoneyInside.QuarterCount.Should().Be(4);
            snackMachine.MoneyInside.OneDollarCount.Should().Be(0);
        }

        [Fact]
        public void After_purchase_change_is_returned()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadSnack(1, new SnackPile(new Snack("Some snack"), 1, 0.5m));
            snackMachine.LoadMoney(Money.TenCent * 10);

            snackMachine.InsertMoney(Money.OneDollar);
            snackMachine.BuySnack(1);

            snackMachine.MoneyInside.Amount.Should().Be(1.5m);
            snackMachine.MoneyInTransaction.Should().Be(0);
        }
    }
}
