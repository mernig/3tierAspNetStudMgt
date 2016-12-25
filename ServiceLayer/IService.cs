using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IService
    {
        IEnumerable<StudentService> GetStudents();
        StudentService GetStudentByID(string studentId);
        void InsertStudent(StudentService student);
        void DeleteStudent(string studentID);
        void UpdateStudent(StudentService student);
        void Save();
    }
    public interface CourseInterface
    {
        IEnumerable<CourseService> GetCourses();
        CourseService GetCourseByID(string ccode);
        void InsertCourse(CourseService course);
        void DeleteCourse(string ccode);
        void UpdateCourse(CourseService course);
        void Save();
    }
    public interface EmployeeInterface 
    {
        IEnumerable<EmployeeService> GetEmployee();
        EmployeeService GetEmployeeByID(string empId);
        void InsertEmployee(EmployeeService empl);
        void DeleteEmployee(string empId);
        void UpdateEmployee(EmployeeService empl);
        void Save();
    }
}

