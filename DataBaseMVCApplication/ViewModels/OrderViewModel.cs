using DataBaseMVCApplication.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DataBaseMVCApplication.ViewModels
{
    public class OrderViewModel
    {
        [DisplayName("Номер заказа")]
        public long Id { get; set; }
        public long SellerId { get; set; }
        public long BuyerId { get; set; }
        public Seller Seller { get; set; }
        public Buyer Buyer { get; set; }
        [DisplayName("Нужна доставка")]
        public bool IsDeliver { get; set; }
        [DisplayName("Нужна установка")]
        public bool IsSetup { get; set; }
        [DisplayName("Дата заказа")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Дата доставки")]
        public DateTime? DeliverDate { get; set; }
        [DisplayName("Дата установки")]
        public DateTime? SetupDate { get; set; }
        [DisplayName("Цена")]
        public double Price { get; set; }
        public ICollection<OrderPositionViewModel> OrderPositions { get; set; }
    }
}