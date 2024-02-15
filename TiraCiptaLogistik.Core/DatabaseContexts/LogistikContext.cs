using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiraCiptaLogistik.Domain.Entities;

namespace TiraCiptaLogistik.Core.DatabaseContexts
{
    public class LogistikContext : DbContext
    {
        public LogistikContext(DbContextOptions<LogistikContext> options) : base(options)
        {

        }

        // Tambahkan DbSet untuk setiap entitas yang akan di-map ke database
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
        public DbSet<SalesOrderInterface> SalesOrderInterface { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>(ConfigurePrice);
            modelBuilder.Entity<Price>().HasNoKey();
        }

        private void ConfigurePrice(EntityTypeBuilder<Price> builder)
        {
            // Other property configurations...
            builder.Property(p => p.PriceValue).HasConversion<decimal>();
        }
    }


}
