using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Domain
{
   public partial class OrderPosition
    {
        public long OrderPositionId { get; set; }
        public Nullable<long> OrderId { get; set; }
        public virtual Order Order { get; set; }
        public Nullable<long> WindowId { get; set; }
        public virtual Window Window { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
    }
}
