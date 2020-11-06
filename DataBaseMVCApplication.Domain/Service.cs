using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Domain
{
    public class Service:BaseEntity
    {
        public string Name { get; set; }
        public double PriceToOne { get; set; }
    }
}
