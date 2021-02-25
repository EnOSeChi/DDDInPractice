using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic
{
    public sealed class Money : ValueObject
    {
        public Money(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuarterCount = quarterCount;
            OneDollarCount = oneDollarCount;
            FiveDollarCount = fiveDollarCount;
            TwentyDollarCount = twentyDollarCount;
        }

        public int OneCentCount { get; private set; }
        public int TenCentCount { get; private set; }
        public int QuarterCount { get; private set; }
        public int OneDollarCount { get; private set; }
        public int FiveDollarCount { get; private set; }
        public int TwentyDollarCount { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return OneCentCount;
            yield return TenCentCount;
            yield return QuarterCount;
            yield return OneDollarCount;
            yield return FiveDollarCount;
            yield return TwentyDollarCount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.OneCentCount += money2.OneCentCount,
                money1.TenCentCount += money2.TenCentCount,
                money1.QuarterCount += money2.QuarterCount,
                money1.OneDollarCount += money2.OneDollarCount,
                money1.FiveDollarCount += money2.FiveDollarCount,
                money1.TwentyDollarCount += money2.TwentyDollarCount);

            return sum;
        }
    }
}
