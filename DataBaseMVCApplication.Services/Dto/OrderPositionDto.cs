using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Services
{
    public class OrderPositionDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long WindowId { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
    }
}
