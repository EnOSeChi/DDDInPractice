using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic
{
    public class Slot : Entity
    {
        public Slot(Snack snack, int quantity, decimal price, SnackMachine snackMachine, int position)
        {
            Snack = snack;
            Quantity = quantity;
            Price = price;
            SnackMachine = snackMachine;
            Position = position;
        }

        public Snack Snack { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public SnackMachine SnackMachine { get; private set; }
        public int Position { get; private set; }
    }
}
