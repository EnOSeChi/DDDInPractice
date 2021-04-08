using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic.Atms
{
    public class Atm : AggregateRoot
    {
        public virtual Money MoneyInside { get; protected set; }
        public virtual decimal MoneyCharged { get; protected set; }

        public virtual void TakeMoney(decimal amount)
        {

        }
    }
}
