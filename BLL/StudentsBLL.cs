using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentsBLL
    {
        private ImplStudentsDAL studentObj;
        //Constructor
        public StudentsBLL()
        {
            studentObj = new ImplStudentsDAL();
        }

        public Student GetStudentByIDBL(string id)
        {
            var stud = studentObj.GetStudentByID(id);
            return stud;
        }

        public IEnumerable<Student> GetStudentsBL()
        {
            return studentObj.GetStudents();
        }
        public void InsertStudentBL(Student stud)
        {
            studentObj.InsertStudent(stud);
        }

        public void DeleteStudentBL(string studentID)
        {

            Student stud = studentObj.GetStudentByID(studentID);
            studentObj.DeleteStudent(studentID);
        }

        public void UpdateStudentBL(Student student)
        {
            studentObj.UpdateStudent(student);
        }

        public void SaveBL()
        {
            studentObj.Save();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    studentObj.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}


