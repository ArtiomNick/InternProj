using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using Domain.Dto;
using Repository;

namespace Mvc_v1.Controllers
{
    public class EmployeeGridController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: EmployeeGrid
        public ActionResult Index()
        {
            return View(unitOfWork.EmployeeRepository.GetAllEmployees());
        }



        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
