using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;
namespace DAL
{
    /*
    public class ImplStudentsServiceLayer : IService, IDisposable
    {
        private ContextELearningDBEntities context;
       // List<StudentService> studService = new List<StudentService>();

        public ImplStudentsServiceLayer(ContextELearningDBEntities context)
        {
            this.context = context;
        }
        public IEnumerable<StudentService> GetStudents()
        {
            return context.Students.ToList();
        }

        public Student GetStudentByID(string id)
        {
            return context.Students.Find(id);
        }

        public void InsertStudent(Student student)
        {
            context.Students.Add(student);
        }

        public void DeleteStudent(string studentID)
        {
            Student student = context.Students.Find(studentID);
            context.Students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            context.Entry(student).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
    */
}

