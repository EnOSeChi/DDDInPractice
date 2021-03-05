using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDInPractice.Logic
{
    public sealed class SnackMachine : AggregateRoot
    {
        // how much machine have
        public Money MoneyInside { get; private set; } = Money.None;
        // how much is inserted by user
        public Money MoneyInTransaction { get; private set; } = Money.None;
        private IList<Slot> Slots { get; private set; }

        public SnackMachine()
        {
            Slots = new List<Slot>
            {
                new Slot(this, 0),
                new Slot(this, 1),
                new Slot(this, 2),
            };
        }

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

        public void BuySnack(int position)
        {
            Slot slot = GetSlot(position);
            slot.SnackPile = slot.SnackPile.SubtractOne();
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = Money.None;
        }

        public void LoadSnack(int position, SnackPile snackPile)
        {
            Slot slot = GetSlot(position);
            slot.SnackPile = snackPile;
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(x => x.Position == position);
        }

        public SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }
    }
}
