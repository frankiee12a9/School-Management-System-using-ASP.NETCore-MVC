using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klas_mvc.Areas.Student.Controllers
{
	[Area("Student")]
	[Authorize]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
