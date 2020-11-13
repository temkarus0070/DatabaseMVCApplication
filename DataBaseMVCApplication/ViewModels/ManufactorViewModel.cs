using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DataBaseMVCApplication.ViewModels
{
    public class ManufactorViewModel
    {
        public long Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Адрес")]
        public string Address { get; set; }
        [DisplayName("Телефон")]
        public string Phone { get; set; }
        [DisplayName("Электронная почта")]
        public string Email { get; set; }

    }
}