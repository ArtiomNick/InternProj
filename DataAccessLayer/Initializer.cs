using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EmployeeManagementContext>
    {
        protected override void Seed(EmployeeManagementContext context)
        {
            var departments = new List<Department>
            {
                //new Department{ DepartmentName = "dep1", ManagerName = "man1" },
                //new Department{ DepartmentName = "dep2", ManagerName = "man2" }
            };
            
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            //var employees = new List<Employee>
            //{
            //new Employee{ FirstName = "FirstName1", LastName = "LastName1", Email = "email1@mail.com", DateOfEmployment = DateTime.Parse("2000-09-01"), },
            //new Employee{ FirstName = "FirstName2", LastName = "LastName2", Email = "email2@mail.com", DateOfEmployment = DateTime.Parse("2000-09-01")},
            //new Employee{ FirstName = "FirstName3", LastName = "LastName3", Email = "email3@mail.com", DateOfEmployment = DateTime.Parse("2000-09-01")}
            //};

            //employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            
            
        }

    }
}