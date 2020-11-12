using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Services
{
    public class BuyerDto
    {
        public long Id { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public bool IsLegalEntity { get; set; }
    }
}
