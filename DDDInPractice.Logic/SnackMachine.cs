using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic
{
    public sealed class SnackMachine
    {
        // how much machine have
        public int OneCentCount { get; private  set; }
        public int TenCentCount { get; private set; }
        public int QuarterCount { get; private set; }
        public int OnDollarCount { get; private set; }
        public int FiveDollarCount { get; private set; }
        public int TwentyDollarCount { get; private set; }
        // how much is inserted by user
        public int OneCentCountInTransaction { get; private set; }
        public int TenCentCountInTransaction { get; private set; }
        public int QuarterCountInTransaction { get; private set; }
        public int OnDollarCountInTransaction { get; private set; }
        public int FiveDollarCountInTransaction { get; private set; }
        public int TwentyDollarCountInTransaction { get; private set; }

        public void InsertMoney(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            OneCentCountInTransaction += oneCentCount;
            TenCentCountInTransaction += tenCentCount;
            QuarterCountInTransaction += quarterCount;
            OnDollarCountInTransaction += oneDollarCount;
            FiveDollarCountInTransaction += fiveDollarCount;
            TwentyDollarCountInTransaction += twentyDollarCount;
        }

        public void ReturnMoney()
        {
            OneCentCountInTransaction = 0;
            TenCentCountInTransaction = 0;
            QuarterCountInTransaction = 0;
            OnDollarCountInTransaction = 0;
            FiveDollarCountInTransaction = 0;
            TwentyDollarCountInTransaction = 0;
        }

        public void BuySnack()
        {
            OneCentCount += OneCentCountInTransaction;
            TenCentCount += TenCentCountInTransaction;
            QuarterCount += QuarterCountInTransaction;
            OnDollarCount += OnDollarCountInTransaction;
            FiveDollarCount += FiveDollarCountInTransaction;
            TwentyDollarCount += TwentyDollarCountInTransaction;

            OneCentCountInTransaction = 0;
            TenCentCountInTransaction = 0;
            QuarterCountInTransaction = 0;
            OnDollarCountInTransaction = 0;
            FiveDollarCountInTransaction = 0;
            TwentyDollarCountInTransaction = 0;
        }
    }
}
