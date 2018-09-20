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
using Repository;

namespace Mvc_v1.Controllers
{
    public class SalaryController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Salaries
        public ActionResult Index()
        {
            var salaries = unitOfWork.SalaryRepository.GetAll<Salary>();
            return View(salaries.ToList());
        }

        // GET: Salaries/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Salary salary = unitOfWork.SalaryRepository.GetById<Salary>(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // GET: Salaries/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(unitOfWork.EmployeeRepository.GetAll<Salary>(), "Id", "FirstName");
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WorkingHours,SalaryPerHour")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SalaryRepository.Create(salary);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(unitOfWork.EmployeeRepository.GetAll<Salary>(), "Id", "FirstName");
            return View(salary);
        }

        // GET: Salaries/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Salary salary = unitOfWork.SalaryRepository.GetById<Salary>(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(unitOfWork.EmployeeRepository.GetAll<Salary>(), "Id", "FirstName", salary.Id);
            return View(salary);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WorkingHours,SalaryPerHour")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SalaryRepository.Update(salary);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(unitOfWork.EmployeeRepository.GetAll<Salary>(), "Id", "FirstName", salary.Id);
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Salary salary = unitOfWork.SalaryRepository.GetById<Salary>(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salary salary = unitOfWork.SalaryRepository.GetById<Salary>(id);
            unitOfWork.SalaryRepository.Delete(salary);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
