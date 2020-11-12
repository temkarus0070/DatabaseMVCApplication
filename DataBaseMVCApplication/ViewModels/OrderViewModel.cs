using DataBaseMVCApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBaseMVCApplication.ViewModels
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public long SellerId { get; set; }
        public long BuyerId { get; set; }
        public Seller Seller { get; set; }
        public Buyer Buyer { get; set; }
        public bool IsDeliver { get; set; }
        public bool IsSetup { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliverDate { get; set; }
        public DateTime SetupDate { get; set; }
        public double Price { get; set; }
        public ICollection<OrderPosition> OrderPositions { get; set; }
    }
}