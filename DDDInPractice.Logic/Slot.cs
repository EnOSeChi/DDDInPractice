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

        public Snack Snack { get;  set; }
        public int Quantity { get;  set; }
        public decimal Price { get;  set; }
        public SnackMachine SnackMachine { get;  set; }
        public int Position { get; set; }
    }
}
