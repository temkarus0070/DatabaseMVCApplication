using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Domain
{
   public partial class OrderPosition:BaseEntity
    {
        [ForeignKey("Order")]
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("Window")]
        public long WindowId { get; set; }
        public virtual Window Window { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
    }
}
