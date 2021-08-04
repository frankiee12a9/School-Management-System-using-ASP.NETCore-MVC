using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsLayer.Models
{
    public class AppUser : IdentityUser
    {
        // [Required(AllowEmptyStrings = true)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string UserType { get; set; }
        public int? DepartmentID { get; set; }
        public Department Department { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
