using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsLayer.Models
{
	/*
	 NOTE: When creating new migration (Model) and have certain navigation properties to the existing table which has some 
	already inserted row data. The foreign key (from newly created table: Principal table) reference to existing table(Dependent Table) 
	must be set to NULLABLE. If not that the error `The ALTER TABLE statement conflicted with the FOREIGN KEY constraint` will occured.
	 */
	public class Department
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int DepartmentID { get; set; }
		public string DepartmentName { get; set; }
		public ICollection<Course> Courses { get; set; }
		public ICollection<AppUser> Identities { get; set; } // lecturer or student
	}
}