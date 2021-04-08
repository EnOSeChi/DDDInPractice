using DDDInPractice.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Application
{
    public class Repository<T> where T : AggregateRoot
    {
        public T GetById(long id)
        {
            using (var ctx = ContextFactory.DefaultContext())
            {
                return ctx.Find<T>(id);
            }
        }

        public void Save(T aggregateRoot)
        {
            using (var ctx = ContextFactory.DefaultContext())
            using(var tran = ctx.Database.BeginTransaction())
            {
                ctx.Update(aggregateRoot);
                ctx.SaveChanges();
                tran.Commit();
            }
        }
    }
}
