using MediSmartTestApi.Models;
using Microsoft.EntityFrameworkCore;
using PaymentTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediSmartTestApi.Utilities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>().ToTable("UserData");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            //modelBuilder.Entity<UserData>().ToTable("UserData");
        }
    }
}
