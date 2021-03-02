﻿using DDDInPractice.Logic;
using Microsoft.EntityFrameworkCore;

namespace DDDInPractice.Application
{
    public class DDDInPracticeDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<SnackMachine> SnackMachines { get; set; }

        public DDDInPracticeDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SnackMachine>(e =>
            {
                e.OwnsOne(x => x.MoneyInside);
                e.Ignore(x => x.MoneyInTransaction);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
