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
        public decimal MoneyInTransaction { get; private set; } = 0;
        public IList<Slot> Slots { get; private set; }

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

            MoneyInTransaction += money.Amount;
            MoneyInside += money;
        }

        public void ReturnMoney()
        {
            Money moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
            MoneyInside -= moneyToReturn;
            MoneyInTransaction = 0;
        }

        public void BuySnack(int position)
        {
            Slot slot = GetSlot(position);

            if (slot.SnackPile.Price > MoneyInTransaction)
                throw new InvalidOperationException();

            slot.SnackPile = slot.SnackPile.SubtractOne();

            Money change = MoneyInside.Allocate(MoneyInTransaction - slot.SnackPile.Price);
            if (change.Amount < MoneyInTransaction - slot.SnackPile.Price)
                throw new InvalidOperationException();

            MoneyInside -= change;
            MoneyInTransaction = 0;
        }

        public void LoadSnack(int position, SnackPile snackPile)
        {
            Slot slot = GetSlot(position);
            slot.SnackPile = snackPile;
        }

        public SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }

        public void LoadMoney(Money oneDollar)
        {
            MoneyInside += oneDollar;
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(x => x.Position == position);
        }
    }
}
