using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic
{
    public sealed class SnackPile : ValueObject
    {
        private SnackPile() { }

        public SnackPile(Snack snack, int quantity, decimal price) : this()
        {
            if (quantity < 0)
                throw new InvalidOperationException();
            if (price < 0)
                throw new InvalidOperationException();
            if (price % 0.01m > 0)
                throw new InvalidOperationException();

            Snack = snack;
            Quantity = quantity;
            Price = price;
        }

        public Snack Snack { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Snack;
            yield return Quantity;
            yield return Price;
        }

        internal SnackPile SubtractOne()
        {
            return new SnackPile(Snack, Quantity - 1, Price);
        }
    }
}
