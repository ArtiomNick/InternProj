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
    public class EventController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Event
        public ActionResult Index()
        {
            var events = unitOfWork.EventRepository.GetAll<Event>();
            return View(events);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Event @event = unitOfWork.EventRepository.GetById<Event>(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventName,EventDate,StartTime,EndTime,Subject")] Event @event)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.EventRepository.Create(@event);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Event @event = unitOfWork.EventRepository.GetById<Event>(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EventName,EventDate,StartTime,EndTime,Subject")] Event @event)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.EventRepository.Update(@event);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Event @event = unitOfWork.EventRepository.GetById<Event>(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = unitOfWork.EventRepository.GetById<Event>(id);
            unitOfWork.EventRepository.Delete(@event);
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
