using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLayer.Models
{
	public class CourseFileUpload: FileUpload
	{
		public Byte[] Data { get; set; }
		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}
