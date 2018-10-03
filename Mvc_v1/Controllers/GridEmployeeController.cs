using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_v1.Controllers
{
    public class GridEmployeeController : Controller
    {
        private readonly IServiceEmployee service;
        public GridEmployeeController(IServiceEmployee serviceEmployee)
        {
            this.service = serviceEmployee;
        }

        // GET: GridEmployee
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCustomers(string word, int page, int rows, string searchString)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var employeeDtos = service.GetAllEmployeesQ();

            int totalRecords = employeeDtos.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (word.ToUpper() == "DESC")
            {
                employeeDtos = employeeDtos.OrderByDescending(e => e.Id);
                employeeDtos = employeeDtos.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                employeeDtos = employeeDtos.OrderBy(s => s.Id);
                employeeDtos = employeeDtos.Skip(pageIndex * pageSize).Take(pageSize);
            }


            if (!string.IsNullOrEmpty(searchString))
            {
                employeeDtos = employeeDtos.Where(m => m.DepartmentName == searchString);
            }

            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = employeeDtos
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);


            
        }
    }
}