using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic
{
    public class Slot : Entity
    {
        public Slot(SnackMachine snackMachine, int position)
        {
            SnackPile = new SnackPile(null, 0, 0m);
            SnackMachine = snackMachine;
            Position = position;
        }

        public SnackPile SnackPile { get; set; }
        public SnackMachine SnackMachine { get;  private set; }
        public int Position { get; private set; }
    }
}
