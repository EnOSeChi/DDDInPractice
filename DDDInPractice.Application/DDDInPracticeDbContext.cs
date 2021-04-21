using DDDInPractice.Logic;
using DDDInPractice.Logic.Atms;
using DDDInPractice.Logic.Management;
using Microsoft.EntityFrameworkCore;

namespace DDDInPractice.Application
{
    public class DDDInPracticeDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Atm> Atms { get; set; }
        public DbSet<SnackMachine> SnackMachines { get; set; }
        public DbSet<Snack> Snacks { get; set; }
        public DbSet<Slot> Slots { get; set; }

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
            modelBuilder.Entity<Atm>(e =>
            {
                e.OwnsOne(x => x.MoneyInside);
            });

            modelBuilder.Entity<SnackMachine>(e =>
            {
                e.OwnsOne(x => x.MoneyInside);
                e.Ignore(x => x.MoneyInTransaction);
            });

            modelBuilder.Entity<Slot>(e =>
            {
                e.OwnsOne(x => x.SnackPile);
            });

            modelBuilder.Entity<HeadOffice>(e =>
            {
                e.OwnsOne(x => x.Cash);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
