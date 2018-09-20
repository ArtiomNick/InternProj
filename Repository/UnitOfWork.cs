using DataAccessLayer;
using Domain;
using Repository.Interfaces;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository
{
    public class UnitOfWork
    {
        private EmployeeManagementContext context = new EmployeeManagementContext();
        private Repository<Department> departmentRepository;
        private Repository<Employee> employeeRepository;
        private Repository<Salary> salaryRepository;
        private Repository<Shift> shiftRepository;
        private Repository<Event> eventRepository;
        private Repository<PersonalData> personalDataRepository;


        public Repository<Department> DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new Repository<Department>(context);
                }
                return departmentRepository;
            }
        }

        public Repository<Employee> EmployeeRepository
        {
            get
            {

                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new Repository<Employee>(context);
                }
                return employeeRepository;
            }
        }
        public Repository<Shift> ShiftRepository
        {
            get
            {

                if (this.shiftRepository == null)
                {
                    this.shiftRepository = new Repository<Shift>(context);
                }
                return shiftRepository;
            }
        }

        public Repository<Salary> SalaryRepository
        {
            get
            {

                if (this.salaryRepository == null)
                {
                    this.salaryRepository = new Repository<Salary>(context);
                }
                return salaryRepository;
            }
        }

        public Repository<Event> EventRepository
        {
            get
            {

                if (this.eventRepository == null)
                {
                    this.eventRepository = new Repository<Event>(context);
                }
                return eventRepository;
            }
        }

        public Repository<PersonalData> PersonalDataRepository
        {
            get
            {

                if (this.personalDataRepository == null)
                {
                    this.personalDataRepository = new Repository<PersonalData>(context);
                }
                return personalDataRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}