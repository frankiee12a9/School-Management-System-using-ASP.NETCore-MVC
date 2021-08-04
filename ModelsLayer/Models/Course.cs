using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsLayer.Models
{
    public class Course : CourseSchedule
    {
        [Display(Name = "Course ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Course Type")]
        public string CourseType { get; set; }
        [Display(Name = "Course Credit")]
        public int CourseCredit { get; set; }
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }
        public int? DepartmentID { get; set; }
        public Department Department { get; set; }
        public ICollection<CourseFileUpload> CourseFiles { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseTaskAssignment> CourseTaskAssignments { get; set; }
    }
}
