using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Dto;
using Repository.Interfaces;

namespace ServiceLayer
{
    public class ServiceDepartment : IServiceDepartment
    {
        private IRepository Repository { get; }

        public ServiceDepartment(IRepository repository)
        {
            this.Repository = repository;
        }

        public IList<DepartmentDto> GetAllDepartments()
        {
            var departments = from d in Repository.GetAll<Department>()
                              select new DepartmentDto()
                              {
                                  Id = d.Id,
                                  DepartmentName = d.DepartmentName,
                                  ManagerName = d.ManagerName,
                                  NumberOfEmployees =
                                        (from e in Repository.GetAll<Employee>()
                                         where e.DepartmentId == d.Id
                                         select e).Count()
                              };
            return departments.ToList();
        }
    }
}
