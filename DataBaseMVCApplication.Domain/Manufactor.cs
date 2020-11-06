using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Domain
{
    public partial class Manufactor:BaseEntity
    {
        public Manufactor()
        {
            this.Windows = new HashSet<Window>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Window> Windows { get; set; }
    }
}
