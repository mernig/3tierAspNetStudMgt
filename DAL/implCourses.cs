using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class implCourses : CourseInterface
    {
        private ContextELearningDBEntities context;
        public implCourses()
        {
            context = new ContextELearningDBEntities(); 
        }

        public IEnumerable<Cours> GetCourses()
        {
            return context.Courses.ToList();
        }

        public Cours GetSCourseByID(string CCode)
        {
            return context.Courses.Find(CCode);
        }
        public void InsertCourse(Cours course)
        {
             context.Courses.Add(course);
        }
        public void DeleteCourse(string CCode)
        {
            Cours crs = context.Courses.Find(CCode);
            context.Courses.Remove(crs);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void UpdateCourse(Cours course)
        {
            context.Entry(course).State = System.Data.Entity.EntityState.Modified;
        }

    }
}
