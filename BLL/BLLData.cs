using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [DataContract]
    public class StudentData
    {
       [DataMember]
        public string userID { get; set; }
        [DataMember]
        public string phoneNumber { get; set; }
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public Nullable<System.DateTime> enrollmentDate { get; set; }
        [DataMember]
        public Nullable<int> academicYear { get; set; }
    }
    [DataContract]
    public class BLLData
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public Nullable<int> Credits { get; set; }
        [DataMember]
        public Nullable<int> DepartmentID { get; set; }
        [DataMember]
        public string dataInstructor { get; set; }
        [DataMember]
        public string CourseCode { get; set; }
    }
    [DataContract]
    public class EmplData
    {
        [DataMember]
        public string userID { get; set; }
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string emailAddress { get; set; }
        [DataMember]
        public string phoneNumber { get; set; }
        [DataMember]
        public string lastName { get; set; }
    }

}
