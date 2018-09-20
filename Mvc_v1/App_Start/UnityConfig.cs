using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Repository.Interfaces;
using Domain;
using Repository.Implementation;

namespace Mvc_v1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<IRepository<Employee>, Repository<Employee>>();
            //container.RegisterType<IRepository<Department>, Repository<Department>>();
            //container.RegisterType<IRepository<Shift>, Repository<Shift>>();
            //container.RegisterType<IRepository<Salary>, Repository<Salary>>();
            //container.RegisterType<IRepository<Event>, Repository<Event>>();
            //container.RegisterType<IRepository<PersonalData>, Repository<PersonalData>>();
            container.RegisterType<IRepository, Repository.Implementation.Repository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}