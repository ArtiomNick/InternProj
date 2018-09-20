using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Salary : EntityBase
    {
        public int WorkingHours { get; set; }
        public int SalaryPerHour { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
