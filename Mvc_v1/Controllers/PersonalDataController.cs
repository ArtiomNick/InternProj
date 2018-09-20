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

namespace Mvc_v1.Controllers
{
    public class PersonalDataController : Controller
    {
        private EmployeeManagementContext db = new EmployeeManagementContext();

        // GET: PersonalData
        public ActionResult Index()
        {
            var personalDatas = db.PersonalDatas.Include(p => p.Employee);
            return View(personalDatas.ToList());
        }

        // GET: PersonalData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalData personalData = db.PersonalDatas.Find(id);
            if (personalData == null)
            {
                return HttpNotFound();
            }
            return View(personalData);
        }

        // GET: PersonalData/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Employees, "Id", "FirstName");
            return View();
        }

        // POST: PersonalData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Adress,PhoneNumber,DateOfBirth")] PersonalData personalData)
        {
            if (ModelState.IsValid)
            {
                db.PersonalDatas.Add(personalData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Employees, "Id", "FirstName", personalData.Id);
            return View(personalData);
        }

        // GET: PersonalData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalData personalData = db.PersonalDatas.Find(id);
            if (personalData == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Employees, "Id", "FirstName", personalData.Id);
            return View(personalData);
        }

        // POST: PersonalData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adress,PhoneNumber,DateOfBirth")] PersonalData personalData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Employees, "Id", "FirstName", personalData.Id);
            return View(personalData);
        }

        // GET: PersonalData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalData personalData = db.PersonalDatas.Find(id);
            if (personalData == null)
            {
                return HttpNotFound();
            }
            return View(personalData);
        }

        // POST: PersonalData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalData personalData = db.PersonalDatas.Find(id);
            db.PersonalDatas.Remove(personalData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
