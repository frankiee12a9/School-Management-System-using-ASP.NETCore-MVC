using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsLayer.Models.AccountModels
{
	public class UserRoleViewModel
	{
		[Display(Name = "User ID")]
		public string UserId { get; set; }
		[Display(Name = "User Name")]
		public string UserName { get; set; }
		public virtual IEnumerable<string> Roles { get; set; }
	}
}
