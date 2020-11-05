using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Domain
{
    public class Window:BaseEntity
    {
        public long ManufactorId { get; set; }
        public Manufactor Manufactor { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public bool Having { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
    }
}
