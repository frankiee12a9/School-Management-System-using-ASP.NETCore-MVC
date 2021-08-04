using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLayer.Models
{
	public class Enrollment
	{
		public int EnrollmentId { get; set; }
		public string Grade { get; set; }
		public int CourseId { get; set; }
		public Course Course { get; set; }
		public string StudentId { get; set; }
		public AppUser Student { get; set; }
	}
}
