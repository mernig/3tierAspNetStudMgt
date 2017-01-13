using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace camp.Models
{
    public class StudentsModel
    {
        [System.ComponentModel.DisplayName("User Id")]
        [Key]
        public string userID { get; set; }
        [DisplayName("Phone Number")]
        public string phoneNumber { get; set; }
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Enrollment Date")]
        public Nullable<System.DateTime> enrollmentDate { get; set; }
        [DisplayName("Academic Year")]
        public Nullable<int> academicYear { get; set; }
        }
    
}