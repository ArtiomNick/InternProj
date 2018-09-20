using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using Domain;
using Mvc_v1.Models;
using Repository;

namespace Mvc_v1.Controllers
{
    public class EmployeeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Employee
        public ActionResult Index(/*string sortOrder*/)
        {
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "FirstName_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "DateOfEmployment" ? "DateOfEmployment_desc" : "DateOfEmployment";

            var employees = unitOfWork.EmployeeRepository.GetAll();
            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(long id)
        {
            //id was nullable
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            */

            Employee employee = unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(unitOfWork.DepartmentRepository.GetAll(), "Id", "DepartmentName");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,DateOfEmployment,DepartmentId")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                var employee = MapToEmployee(employeeModel);
                unitOfWork.EmployeeRepository.Create(employee);
                unitOfWork.Save();
                return RedirectToAction("Index");
            };

            ViewBag.DepartmentId = new SelectList(unitOfWork.DepartmentRepository.GetAll(), "Id", "DepartmentName");
            return View(employeeModel);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(long id)
        {
            //id was nullable int
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var employee = unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            var employeeModel = new EmployeeModel { Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfEmployment = employee.DateOfEmployment,
                Email = employee.Email,
                DepartmentId = employee.DepartmentId };

            ViewBag.DepartmentId = new SelectList(unitOfWork.DepartmentRepository.GetAll(), "Id", "DepartmentName", employee.DepartmentId);
            return View(employeeModel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,DateOfEmployment,DepartmentId")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                var employee = unitOfWork.EmployeeRepository.GetById(employeeModel.Id);
                employee.FirstName = employeeModel.FirstName;
                employee.LastName = employeeModel.LastName;
                employee.Email = employeeModel.Email;
                employee.DateOfEmployment = employeeModel.DateOfEmployment;
                employee.DepartmentId = employeeModel.DepartmentId;
                unitOfWork.EmployeeRepository.Update(employee);
                unitOfWork.Save();

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(unitOfWork.DepartmentRepository.GetAll(), "Id", "DepartmentName", employeeModel.DepartmentId);
            return View(employeeModel);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(long id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Employee employee = unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Employee employee = unitOfWork.EmployeeRepository.GetById(id);
            unitOfWork.EmployeeRepository.Delete(employee);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

        private Employee MapToEmployee(EmployeeModel model)
        {
            return new Employee(model.FirstName, model.LastName, model.Email, model.DateOfEmployment, model.DepartmentId);
        }

    }
}
