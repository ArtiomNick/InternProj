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
    public class EmployeeRepository : Repository, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeManagementContext context) : base(context)
        {
        }

        public IList<EmployeeDto> GetAllEmployees()
        {
            var employees = from e in context.Employees
                               select new EmployeeDto()
                               {
                                   Id = e.Id,
                                   FirstName = e.FirstName,
                                   LastName = e.LastName,
                                   Email = e.Email,
                                   DateOfEmployment = e.DateOfEmployment,
                                   DepartmentName = e.Department.DepartmentName
                               };


            return employees.ToList();
        }
    }
}
