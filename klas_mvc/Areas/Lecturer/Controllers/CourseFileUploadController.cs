using DataLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace klas_mvc.Areas.Lecturer.Controllers
{
	[Area("Lecturer")]
	[Authorize]
	public class CourseFileUploadController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CourseFileUploadController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			List<SelectListItem> listItem = new List<SelectListItem>();
			var courses = await _context.Courses.ToListAsync();
			foreach (var course in courses)
			{
				listItem.Add(new SelectListItem { Text = course.CourseName, Value = course.CourseId.ToString() });
			}

			ViewBag.CourseList = listItem;
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetUploadFileByCourseId(int id)
		{
			var noteModel = await _context.Courses
					.Include(n => n.CourseFiles)
					.AsNoTracking()
					.FirstOrDefaultAsync(m => m.CourseId == id);

			if (noteModel == null)
				return Json(new { data = NotFound(), message = "Error while retrieving data." });

			return Json(noteModel);
		}


		public async Task<IActionResult> Detail(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var fileUpload = await _context.CourseFileUploads
				.FirstOrDefaultAsync(cf => cf.CourseId == id);

			if (fileUpload	== null)
			{
				return NotFound();  
			}

			return View(fileUpload);
		}


		[HttpPost]
		public async Task<IActionResult> UploadNoteToDB(List<IFormFile> files, string description, int courseId)
		{
			foreach (var file in files)
			{
				var fileName = Path.GetFileNameWithoutExtension(file.FileName);
				var extension = Path.GetExtension(file.FileName);
				var fileUploadModel = new CourseFileUpload
				{
					CourseId = courseId,
					CreatedOn = DateTime.Now,
					FileType = file.ContentType,
					Extension = extension,
					Name = fileName,
					Description = description
				};

				using (var dataStream = new MemoryStream())
				{
					await file.CopyToAsync(dataStream);
					fileUploadModel.Data = dataStream.ToArray();
				}

				_context.CourseFileUploads.Add(fileUploadModel);
				await _context.SaveChangesAsync();
			}

			TempData["Message"] = "File successfully updated to Database.";
			return RedirectToAction("Index");
		}

		// download file that attached in notice 
		public async Task<IActionResult> DownloadNoteFromDB(int id)
		{
			var file = await _context.CourseFileUploads.Where(x => x.Id == id).FirstOrDefaultAsync();
			if (file == null) return null;
			return File(file.Data, file.FileType, file.Name + file.Extension);
		}

		public async Task<IActionResult> DeleteNoteFromDB(int id)
		{
			var file = await _context.CourseFileUploads.Where(x => x.Id == id).FirstOrDefaultAsync();
			if (file == null) return null;
			_context.CourseFileUploads.Remove(file);
			await _context.SaveChangesAsync();
			TempData["Message"] = $"Removed {file.Name + file.Extension} successfully from database.";
			return RedirectToAction("Index");
		}
	}
}
