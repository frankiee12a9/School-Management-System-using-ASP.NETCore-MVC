using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsLayer.Models.AccountModels
{
	public class RegisterViewModel
	{
		[Required(AllowEmptyStrings = true), MinLength(5),MaxLength(100), Display(Name = "User name")]
		public string UserName { get; set; }
		[Required, DataType(DataType.Password)]
		public string Password { get; set; }
		[DataType(DataType.Password), Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }
	}
}
