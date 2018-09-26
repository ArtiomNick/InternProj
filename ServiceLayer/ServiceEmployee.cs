using Domain;
using Domain.Dto;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class ServiceEmployee : IServiceEmployee
    {
        private IRepository Repository { get; }

        public ServiceEmployee(IRepository repository)
        {
            this.Repository = repository;
        }


        public void CreateEmployee(Employee employee)
        {
            Repository.Create(employee);
            Repository.Save();
        }
        public void EditEmployee(Employee employeeModel, long id)
        {
            var employee = Repository.GetById<Employee>(id);

            employee.FirstName = employeeModel.FirstName;
            employee.LastName = employeeModel.LastName;
            employee.Email = employeeModel.Email;
            employee.DateOfEmployment = employeeModel.DateOfEmployment;
            employee.DepartmentId = employeeModel.DepartmentId;

            Repository.Update<Employee>(employee);
            Repository.Save();
        }

        public void DeleteEmployee(Employee employee)
        {
            Repository.Delete<Employee>(employee);
            Repository.Save();
        }

        public EmployeeDto GetEmployeeDto(long id)
        {
            var result = Repository.GetById<Employee>(id);
            return MapToDto(result);
        }
        public Employee GetEmployee(long id)
        {
            var result = Repository.GetById<Employee>(id);
            return result;
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
                                DepartmentName =
                                        (from d in Repository.GetAll<Department>()
                                         where e.DepartmentId == d.Id
                                         select d.DepartmentName).First()
                                    //e.Department.DepartmentName
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
                DepartmentName =
                        (from d in Repository.GetAll<Department>()
                        where e.DepartmentId == d.Id
                        select d.DepartmentName).First()
                        //e.Department.DepartmentName
           };
        }


    }
}
