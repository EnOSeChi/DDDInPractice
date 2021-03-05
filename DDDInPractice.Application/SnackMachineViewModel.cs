using DDDInPractice.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void ReturnMoney()
        {
            _snackMachine.ReturnMoney();
            // notify
        }

        public void BuySnack()
        {
            _snackMachine.BuySnack(1);
            using (var context = ContextFactory.DefaultContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                if (!context.SnackMachines.AsNoTracking().Any(x => x.Id == _snackMachine.Id))
                {
                    context.SnackMachines.Add(_snackMachine);
                }
                else
                {
                    context.SnackMachines.Update(_snackMachine);
                }

                context.SaveChanges();
                transaction.Commit();
            }
            // notify
        }
    }
}
