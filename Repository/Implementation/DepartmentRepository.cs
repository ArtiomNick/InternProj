using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Domain.Dto;
using Repository.Interfaces;

namespace Repository.Implementation
{
    public class DepartmentRepository : Repository, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeManagementContext context) : base(context)
        {
        }

        public IList<DepartmentDto> GetAllDepartments()
        {
            var departments = from d in context.Departments
                              select new DepartmentDto()
                              {
                                  Id = d.Id,
                                  DepartmentName = d.DepartmentName,
                                  ManagerName = d.ManagerName,
                                  NumberOfEmployees = 
                                        (from e in context.Employees
                                         where e.DepartmentId == d.Id
                                         select e).Count()
                              };
            return departments.ToList();
        }
    }
}

