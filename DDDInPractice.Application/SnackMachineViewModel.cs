using DDDInPractice.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Application
{
    public class SnackMachineViewModel
    {
        private readonly SnackMachine _snackMachine;
        
        public string Caption => "Snack Machine";
        public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();

        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            _snackMachine = snackMachine;
        }

        public void InsertMoney(Money money)
        {
            _snackMachine.InsertMoney(money);
            // notify
        }
    }
}
