using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using PagedList;
using BLL;

namespace camp.Controllers
{
    public class CoursController : Controller
    { 
        private CourseBLL courseObjBl;
        public CoursController()
        {
            courseObjBl = new CourseBLL();
        }
        
        // GET: Cours
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "course_title" : "";
            ViewBag.DateSortParm = sortOrder == "CCode" ? "ccode_desc" : "CCode";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var courses = from s in courseObjBl.GetAllCoursesBL()
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.CourseCode.ToUpper().Contains(searchString.ToUpper())
                                       || s.Title.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "course_title":
                    courses = courses.OrderByDescending(s => s.Title);
                    break;
                case "ccode_desc":
                    courses = courses.OrderByDescending(s => s.CourseCode);
                    break;
                default:  // Name ascending 
                    courses = courses.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(courses.ToPagedList(pageNumber, pageSize));
        }
        // GET: Cours/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours course = courseObjBl.GetCourseByCodeBL(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Cours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cours/Create
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Credits,DepartmentID,dataInstructor,CourseCode")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                courseObjBl.InsertCoursesBL(cours);
                courseObjBl.SaveBL();
                return RedirectToAction("Index");
            }

            return View(cours);
        }

        // GET: Cours/Edit/5
        public ActionResult Edit(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours course = courseObjBl.GetCourseByCodeBL(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }


        // POST: Cours/Edit/5 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Title,Credits,DepartmentID,dataInstructor,CourseCode")] Cours course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    courseObjBl.UpdateCourseBL(course);
                    courseObjBl.SaveBL();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again!");
            }
            return View(course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = courseObjBl.GetCourseByCodeBL(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cours cours = courseObjBl.GetCourseByCodeBL(id);
            courseObjBl.DeleteCourseBL(id);
            courseObjBl.SaveBL(); 
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
