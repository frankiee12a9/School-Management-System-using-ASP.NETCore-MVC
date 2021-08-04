using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelsLayer.Models
{
    // for lecturers
    public class CourseTaskAssignment : FileUpload
    {
        public byte[] Data { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isSubmitted { get; set; }
        // submitted hw evaluation
        public int credit { get; set; }
        public string CommentOnSubmittedHW { get; set; }
        public CourseTaskSubmit CourseTaskSubmit { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; } // lecturer create homework  | student submit homework
    }
}