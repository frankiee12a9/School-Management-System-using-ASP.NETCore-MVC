using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsLayer.Models
{
	public class ManageRolesViewModel
	{ 	
		[Display(Name = "Role ID")]
		public string RoleId { get; set; }
		[Display(Name = "Role Name")]
		public string RoleName { get; set; }
		public bool IsSelectedRole { get; set; }
	}
}
