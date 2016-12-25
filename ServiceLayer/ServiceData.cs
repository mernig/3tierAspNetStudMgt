using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class StudentService  
    {
        public StudentService()
        {

        }
        public string userID { get; set; }
        public string phoneNumber { get; set; }
        public string firstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> enrollmentDate { get; set; }
        public Nullable<int> academicYear { get; set; }
        
    }
    public class CourseService { 
        public CourseService()
        {

        }
        public string Title { get; set; }
        public Nullable<int> Credits { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string dataInstructor { get; set; }
        public string CourseCode { get; set; }
    }
    public class EmployeeService
    {
        public EmployeeService()
        {

        }
        public string userID { get; set; }
        public string firstName { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public string lastName { get; set; }
    }
}
