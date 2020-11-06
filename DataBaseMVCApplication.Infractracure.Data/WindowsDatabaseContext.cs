using DataBaseMVCApplication.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Infractracure.Data
{
    public class WindowsDatabaseContext:DbContext
    {
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Manufactor> Manufactors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrdersPositions { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Window> Windows { get; set; }
    }
}
