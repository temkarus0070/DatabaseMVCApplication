using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Domain
{
    public partial class Seller
    {
        public Seller()
        {
            this.Orders = new HashSet<Order>();
        }

        public long SellerId{get;set;}
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double PercentFromOrder { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
