using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsLayer.Models.AccountModels
{
	public class LoginViewModel
	{
		[Required(AllowEmptyStrings = true)]
		public string UserName { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Display(Name = "Remember Me")]
		public bool RememberMe { get; set; }
		public string ReturnUrl { get; set; }
	}
}
