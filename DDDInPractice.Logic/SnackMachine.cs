using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        // how much machine have
        public Money MoneyInside { get; private set; }
        // how much is inserted by user
        public Money MoneyInTransaction { get; private set; }

        public void InsertMoney(Money money)
        {
            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            //MoneyInTransaction = 0;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            //MoneyInTransaction = 0;
        }
    }
}
