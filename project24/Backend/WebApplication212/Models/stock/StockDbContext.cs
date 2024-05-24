using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace WebApplication212.Models.stock
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options) { }
        public DbSet<StockProduct> StockProducts { get; set; }
        public DbSet<StockPurchase> StockPurchases { get; set; }
        public DbSet<StockSale> StockSales { get; set; }
        public DbSet<StockStock> StockStocks { get; set; }
    }
}
