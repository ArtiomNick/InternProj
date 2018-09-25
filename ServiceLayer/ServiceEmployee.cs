using Domain;
using Domain.Dto;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace ServiceLayer
{
    public class ServiceEmployee : IServiceEmployee
    {
        private IRepository Repository { get; }

        public ServiceEmployee(IRepository repository)
        {
            this.Repository = repository;
        }

        public EmployeeDto GetEmployee(long id)
        {
            var result = Repository.GetById<Employee>(id);
            return MapToDto(result);
        }

        public IList<EmployeeDto> GetAllEmployees()
        {
            var employees = from e in Repository.GetAll<Employee>()
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


        private EmployeeDto MapToDto(Employee e)
        {
           return new EmployeeDto()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DateOfEmployment = e.DateOfEmployment,
                DepartmentName = e.Department.DepartmentName
            };
        }
    }
}
