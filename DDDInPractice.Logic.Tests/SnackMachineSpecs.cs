using FluentAssertions;
using System;
using System.Collections.Generic;
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

            snackMachine.MoneyInTransaction.Amount.Should().Be(0m);
        }

        [Fact]
        public void Inserted_money_goes_to_money_in_transaction()
        {
            var snackMachine = new SnackMachine();

            snackMachine.InsertMoney(Money.OneCent);
            snackMachine.InsertMoney(Money.OneDollar);

            snackMachine.MoneyInTransaction.Amount.Should().Be(1.01m);
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
            snackMachine.LoadSnack();
            snackMachine.InsertMoney(Money.OneDollar);
            snackMachine.InsertMoney(Money.OneDollar);

            snackMachine.BuySnack();

            snackMachine.MoneyInTransaction.Should().Be(Money.None);
            snackMachine.MoneyInside.Amount.Should().Be(2m);
            validate the number
        }
    }
}
