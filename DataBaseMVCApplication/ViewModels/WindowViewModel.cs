using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DataBaseMVCApplication.ViewModels
{
    public class WindowViewModel
    {
        public long Id { get; set; }
        public long ManufactorId { get; set; }
        [DisplayName("Название производителя")]
        public string ManufactorName { get; set; }
        [DisplayName("Цена")]
        public double Price { get; set; }
        [DisplayName("Цвет")]
        public string Color { get; set; }
        [DisplayName("Есть в наличии")]
        public bool Having { get; set; }
        public byte[] Image { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
    }
}