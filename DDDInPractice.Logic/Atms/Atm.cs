using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic.Atms
{
    public class Atm : AggregateRoot
    {
        private const decimal CommisionRate = 0.01m;
        public virtual Money MoneyInside { get; protected set; } = Money.None;
        public virtual decimal MoneyCharged { get; protected set; }

        public virtual void TakeMoney(decimal amount)
        {
            Money output = MoneyInside.Allocate(amount);
            MoneyInside -= output;
            decimal amountWithCommission = CalculateAmountWithCommission(amount);
            MoneyCharged += amountWithCommission;
        }

        private decimal CalculateAmountWithCommission(decimal amount)
        {
            decimal commision = amount * CommisionRate;
            decimal lessThanCent = commision % 0.01m;
            if (lessThanCent > 0)
            {
                commision = commision - lessThanCent + 0.01m;
            }
            return amount + commision;
        }

        public virtual void LoadMoney(Money money)
        {
            MoneyInside += money;
        }
    }
}
