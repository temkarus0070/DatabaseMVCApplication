using DataBaseMVCApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBaseMVCApplication.ViewModels
{
    public class OrderPositionViewModel
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public OrderViewModel Order { get; set; }
        public long WindowId { get; set; }
        public WindowViewModel Window { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
    }
}