using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Domain
{
   public partial class Order
    {
        public Order()
        {
            this.OrderPositions = new HashSet<OrderPosition>();
        }

        public long OrderId { get; set; }
        public Nullable<long> SellerId { get; set; }
        public Nullable<long> BuyerId { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual Buyer Buyer { get; set; }
        public bool IsDeliver { get; set; }
        public bool IsSetup { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliverDate { get; set; }
        public DateTime SetupDate { get; set; }
        public double Price { get; set; }
        public virtual ICollection<OrderPosition> OrderPositions { get; set; }
    }
}
