using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Services
{
    public class SellerDto
    {
        public long Id { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double PercentFromOrder { get; set; }

        public override bool Equals(object obj)
        {
            var obj1 = (SellerDto)obj;
            return obj1.Id==this.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
