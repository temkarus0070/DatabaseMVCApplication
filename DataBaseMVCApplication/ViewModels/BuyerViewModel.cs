using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DataBaseMVCApplication.ViewModels
{
    public class BuyerViewModel
    {
        
        public long Id { get; set; }
        [DisplayName("ФИО")]
        public string FIO { get; set; }
        [DisplayName("Телефон")]
        public string Phone { get; set; }
        [DisplayName("Юридическое лицо")]
        public bool IsLegalEntity { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}