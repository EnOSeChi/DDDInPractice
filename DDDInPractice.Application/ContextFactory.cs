using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Application
{
    public class ContextFactory
    {
        public static DDDInPracticeDbContext DefaultContext()
        {
            return new DDDInPracticeDbContext("Server=localhost\\SQLEXPRESS;Database=DDDInPractice;Trusted_Connection=true");
        }
    }
}
