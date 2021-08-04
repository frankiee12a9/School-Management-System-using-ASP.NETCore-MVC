using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLayer.Models
{
	[Keyless]
	public class CourseAssignment
	{
		// public string Review { get; set; }
		public int CourseId { get; set; }
		public Course Course { get; set; }
		public string LecturerId { get; set; }
		public AppUser Lecturer { get; set; }
	}
}
