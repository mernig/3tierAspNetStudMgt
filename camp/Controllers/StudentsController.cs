using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using DAL; // Problem here
using BLL;

namespace camp.Controllers
{
    public class StudentsController : Controller
    {
        private StudentsBLL studentObjBL; 

        public StudentsController()
        { 
            studentObjBL = new StudentsBLL();
        }

        public StudentsController(StudentsBLL studentInterface)
        {
            this.studentObjBL = studentInterface;
        }
        // GET: Students
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var students = from s in studentObjBL.GetStudentsBL()
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                                       || s.firstName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.enrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.enrollmentDate);
                    break;
                default:  // Name ascending 
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }
        
        public ViewResult Details(string id)
        {
            Student student = studentObjBL.GetStudentByIDBL(id);
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,phoneNumber,firstName,LastName,enrollmentDate,academicYear")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentObjBL.InsertStudentBL(student);
                    studentObjBL.SaveBL();
                    ModelState.AddModelError(string.Empty, "Successfully Saved!");
                    return RedirectToAction("Index");

                }
            }
            catch (DataException /* dex */)
            { 
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again");
            }
            return View(student);
        }
        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentObjBL.GetStudentByIDBL(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID, phoneNumber, firstName, LastName, enrollmentDate, academicYear")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentObjBL.UpdateStudentBL(student);
                    studentObjBL.SaveBL();
                    ModelState.AddModelError(string.Empty, "Successfully Saved!");
                    return RedirectToAction("Index"); 
                }
            }
            catch (DataException /* dex */)
            { 
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(student);
        }
      
        public ActionResult Delete(bool? saveChangesError = false, string id = null)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again";
            }
            Student student = studentObjBL.GetStudentByIDBL(id);
            return View(student);
        }
         
        // POST: /Student/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            try
            {
                Student student = studentObjBL.GetStudentByIDBL(id);
                studentObjBL.DeleteStudentBL(id);
                studentObjBL.SaveBL();
            }
            catch (DataException /* dex */)
            { 
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
