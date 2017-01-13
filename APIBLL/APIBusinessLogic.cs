using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Net.Http;
using DAL;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net.Http.Formatting;

namespace APIBLL
{
    [Export(typeof(IService))]
    public class APIBusinessLogic : ImplStudentsDAL
    {
        private const string ServiceUrl = "http://localhost:10267/Students";

        public void InsertStudent(Student student)
        {
            HttpClient client = new HttpClient();
            Student stud = new Student()
            {
                firstName = student.firstName,
                LastName = student.LastName,
                enrollmentDate = student.enrollmentDate,
                userID = student.userID,
                academicYear = student.academicYear,
                phoneNumber = student.phoneNumber
            };
        }

        public new StudentService GetStudentByID(string studentId)
        {
            return new StudentService
            {
                userID = studentId
            };
        }

        public IEnumerable<StudentService> GetStudents()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(ServiceUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var students = (IList<StudentService>)response.Content.ReadAsAsync<IList<StudentService>>().Result.ToList();
                IList<StudentService> result = new List<StudentService>();
                foreach (var st in students)
                {
                    result.Add(new StudentService()
                    {

                    });
                }
                return result;
            } 
            throw new Exception();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(StudentService student)
        {
            throw new NotImplementedException();
        }
    }
}
