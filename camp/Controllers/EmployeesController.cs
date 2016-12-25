using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using BLL;
using PagedList;

namespace camp.Controllers
{
    public class EmployeesController : Controller
    { 
        private EmployeeBLL emplObjBl = new EmployeeBLL();
 
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "ID" ? "ID_desc" : "ID";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var students = from s in emplObjBl.GetEmployeeBL()
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.lastName.ToUpper().Contains(searchString.ToUpper())
                                       || s.firstName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.lastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.firstName);
                    break; 
                default:  // Name ascending 
                    students = students.OrderBy(s => s.lastName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        // GET: Employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = emplObjBl.GetEmplByIDBL(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,firstName,emailAddress,phoneNumber,lastName")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    emplObjBl.InsertEmployeeBL(employee);
                    emplObjBl.SaveBL();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again");
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = emplObjBl.GetEmplByIDBL(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,firstName,emailAddress,phoneNumber,lastName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                emplObjBl.UpdateEmployeeBL(employee);
                emplObjBl.SaveBL();
                return RedirectToAction("Index");
            }
            return View(employee);
        } 
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Employee employee = emplObjBl.GetEmplByIDBL(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
         
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            emplObjBl.GetEmplByIDBL(id);
            emplObjBl.DeleteEmployeeBL(id);
            emplObjBl.SaveBL();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
