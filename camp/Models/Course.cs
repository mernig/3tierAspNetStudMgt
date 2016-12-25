using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace camp.Models
{
    public class Course
    {
        public string Title { get; set; }
        public Nullable<int> Credits { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string dataInstructor { get; set; }
        public string CourseCode { get; set; }
    }
}