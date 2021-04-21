using DDDInPractice.Logic.Atms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Application
{
    public class AtmViewModel
    {
        private Atm _atm;

        public AtmViewModel(Atm atm)
        {
            _atm = atm;
        }

        private void TakeMoney(decimal amount)
        {
            _atm.TakeMoney(amount);
            NotifyClient($"You have taken {amount.ToString("C2")}");
        }

        private void NotifyClient(string message)
        {
            Console.WriteLine(message);
        }
    }
}
