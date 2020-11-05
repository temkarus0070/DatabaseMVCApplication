using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Domain
{
   public class OrderPosition:BaseEntity
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
    }
}
