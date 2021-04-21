using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic.Management
{
    public class HeadOffice : AggregateRoot
    {
        public virtual decimal Balance { get; set; }
        public virtual Money Cash { get; set; }

        public virtual void ChangeBalance(decimal delta)
        {
            Balance += delta;
        }
    }
}
