using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic
{
    public sealed class SnackPile : ValueObject
    {
        public SnackPile(Snack snack, int quantity, decimal price)
        {
            Snack = snack;
            Quantity = quantity;
            Price = price;
        }

        public Snack Snack { get; }
        public int Quantity { get; }
        public decimal Price { get; }

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
