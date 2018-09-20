using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Department : EntityBase
    {
        public string DepartmentName { get; set; }
        public string ManagerName { get; set; }

        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}