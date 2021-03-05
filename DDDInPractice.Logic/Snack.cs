using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic
{
    public class Snack : Entity
    {
        public string Name { get; private set; }

        public Snack(string name)
        {
            Name = name;
        }
    }
}
