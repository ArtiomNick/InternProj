using DataAccessLayer;
using Domain;
using Repository.Interfaces;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Implementation;

namespace Repository
{
    public class UnitOfWork
    {
        private EmployeeManagementContext context = new EmployeeManagementContext();
        private DepartmentRepository departmentRepository;
        private EmployeeRepository employeeRepository;
        private Implementation.Repository salaryRepository;
        private Implementation.Repository shiftRepository;
        private Implementation.Repository eventRepository;
        private Implementation.Repository personalDataRepository;


        public DepartmentRepository DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new DepartmentRepository(context);
                }
                return departmentRepository;
            }
        }

        public EmployeeRepository EmployeeRepository
        {
            get
            {

                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new EmployeeRepository(context);
                }
                return employeeRepository;
            }
        }
        public Implementation.Repository ShiftRepository
        {
            get
            {

                if (this.shiftRepository == null)
                {
                    this.shiftRepository = new Implementation.Repository(context);
                }
                return shiftRepository;
            }
        }

        public Implementation.Repository SalaryRepository
        {
            get
            {

                if (this.salaryRepository == null)
                {
                    this.salaryRepository = new Implementation.Repository(context);
                }
                return salaryRepository;
            }
        }

        public Implementation.Repository EventRepository
        {
            get
            {

                if (this.eventRepository == null)
                {
                    this.eventRepository = new Implementation.Repository(context);
                }
                return eventRepository;
            }
        }

        public Implementation.Repository PersonalDataRepository
        {
            get
            {

                if (this.personalDataRepository == null)
                {
                    this.personalDataRepository = new Implementation.Repository(context);
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