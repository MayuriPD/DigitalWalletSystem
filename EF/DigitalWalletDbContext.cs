using DigitalWalletSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletSystem.EF
{
    public class DigitalWalletDbContext : DbContext
    {
        public DigitalWalletDbContext()
        {

        }
        public DigitalWalletDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-152FRH1; database=DigitalWalletDb;Trusted_Connection=True;");
        }

        public DbSet<Models.Register> Register { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }

        public DbSet<Account> Account { get; set; }
    }
}
