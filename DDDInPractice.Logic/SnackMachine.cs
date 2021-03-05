using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        // how much machine have
        public Money MoneyInside { get; private set; } = Money.None;
        // how much is inserted by user
        public Money MoneyInTransaction { get; private set; } = Money.None;
        public IList<Slot> Slots { get; private set; }

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = 
            {
                Money.OneCent,
                Money.TenCent,
                Money.Quarter,
                Money.OneDollar,
                Money.FiveDollar,
                Money.TwentyDollar 
            };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = Money.None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = Money.None;
        }

        public void LoadSnack(int position, Snack snack, int quantity, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}
