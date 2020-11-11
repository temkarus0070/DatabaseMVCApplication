using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBaseMVCApplication.ViewModels
{
    public class SellerViewModel
    {
        public long Id { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double PercentFromOrder { get; set; }
    }
}