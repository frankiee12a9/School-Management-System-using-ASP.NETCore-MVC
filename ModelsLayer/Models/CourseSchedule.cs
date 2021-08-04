using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsLayer.Models
{
	public abstract class CourseSchedule
	{
		[Required]
		[Display(Name = "Class 1 Place")]

		public string ClassPlace1 { get; set; }
		[Display(Name = "Class 2 Place")]

		[Required]
		public string ClassPlace2 { get; set; }
		[Required]
		[Display(Name = "Class 1 Time")]
		public string ClassTime1 { get; set; }
		[Display(Name = "Class 2 Time")]

		[Required]
		public string ClassTime2 { get; set; }
		public string Week1 { get; set; }
		public string Week2 { get; set; }
		public string Week3 { get; set; }
		public string Week4 { get; set; }
		public string Week5 { get; set; }
		public string Week6 { get; set; }
		public string Week7 { get; set; }
		public string Week8 { get; set; }
		public string Week9 { get; set; }
		public string Week10 { get; set; }
	}
}
