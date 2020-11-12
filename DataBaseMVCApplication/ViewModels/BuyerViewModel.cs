using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBaseMVCApplication.ViewModels
{
    public class BuyerViewModel
    {
        public long Id { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public bool IsLegalEntity { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}