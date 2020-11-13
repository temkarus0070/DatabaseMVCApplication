using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DataBaseMVCApplication.ViewModels
{
    public class SellerViewModel
    {
        public long Id { get; set; }
        [DisplayName("ФИО")]
        public string FIO { get; set; }
        [DisplayName("Телефон")]
        public string Phone { get; set; }
        [DisplayName("Электронная почта")]
        public string Email { get; set; }
        [DisplayName("Процент от заказа")]
        public double PercentFromOrder { get; set; }
    }
}