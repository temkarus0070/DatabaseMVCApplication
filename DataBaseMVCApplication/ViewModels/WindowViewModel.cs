using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBaseMVCApplication.ViewModels
{
    public class WindowViewModel
    {
        public long Id { get; set; }
        public long ManufactorId { get; set; }
        public string ManufactorName { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public bool Having { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
    }
}