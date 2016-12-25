using DAL; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CourseBLL
    {
        private implCourses courseObj;
        public CourseBLL()
        {
            courseObj = new implCourses();
        }

        public void DeleteCourseBL(string ccode)
        {
            courseObj.DeleteCourse(ccode);
        }

        public Cours GetCourseByCodeBL(string ccode)
        {
           var cours= courseObj.GetSCourseByID(ccode);
            return cours;
        }

        public IEnumerable<Cours> GetAllCoursesBL()
        {
          return  courseObj.GetCourses();
        }

        public void InsertCoursesBL(Cours course)
        {
            courseObj.InsertCourse(course);
        }

        public void SaveBL()
        {
            courseObj.Save();
        }

        public void UpdateCourseBL(Cours course)
        {
            courseObj.UpdateCourse(course);
        }
    }
}
