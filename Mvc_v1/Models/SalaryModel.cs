using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_v1.Models
{
    public class SalaryModel : BaseModel
    {
        public int WorkingHours { get; set; }
        public int SalaryPerHour { get; set; }
    }
}