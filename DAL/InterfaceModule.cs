using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface StudentInterface
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(string studentId);
        void InsertStudent(Student student);
        void DeleteStudent(string studentID);
        void UpdateStudent(Student student);
        void Save(); 
    }
    public interface CourseInterface
    {
        IEnumerable<Cours> GetCourses();
        Cours GetSCourseByID(string CCode);
        void InsertCourse(Cours course);
        void DeleteCourse(string CCode);
        void UpdateCourse(Cours course);
        void Save();
    }
    public interface EmployeeInterface
    {
        IEnumerable<Employee> GetEmployee();
        Employee GetEmplByID(string id);
        void InsertEmployee(Employee empl);
        void DeleteEmployee(string id);
        void UpdateEmployee(Employee empl);
        void Save();
    }
}
