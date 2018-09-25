using Domain;
using Domain.Dto;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ServiceEmployee : IServiceEmployee
    {
        private IUnitOfWork UnitOfWork { get; }

        public ServiceEmployee(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public EmployeeDto GetEmployee(long id)
        {
            var result = UnitOfWork.GetById<Employee>(id);
            return MapToDto(result);
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
