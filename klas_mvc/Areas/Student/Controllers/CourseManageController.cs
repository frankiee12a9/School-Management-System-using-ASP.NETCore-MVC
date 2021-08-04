using DataLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace klas_mvc.Areas.Lecturer.Controllers
{
    [Area("Student")]
    [Authorize]
    public class CourseManageController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> _userManager;

        public CourseManageController(ApplicationDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _db.Courses
                .Include(ca => ca.CourseAssignments)
                    .ThenInclude(l => l.Lecturer)
                .AsNoTracking()
                .ToListAsync();

            return View(courses);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var course = await _db.Courses.Where(c => c.CourseId == id)
                .Include(ca => ca.CourseAssignments)
                    .ThenInclude(l => l.Lecturer)
                .Include(e => e.Enrollments)
                    .ThenInclude(s => s.Student)
                .Include(d => d.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            // get lecturer's role 
            foreach (var courseAssignment in course.CourseAssignments)
            {
                var roles = await _userManager.GetRolesAsync(courseAssignment.Lecturer);
                foreach (var role in roles)
                {
                    ViewData["lecturerType"] = role;
                }
            }

            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var course = new Course();
            PopulateDepartmentsDropdownList();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                await _db.Courses.AddAsync(course);
                try
                {
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                       "Try again, and if the problem persists, " +
                       "see your system administrator.");
                }
            }

            PopulateDepartmentsDropdownList(course.DepartmentID);
            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PopulateDepartmentsDropdownList();
            var courseToEdit = await _db.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (courseToEdit == null)
            {
                return NotFound();
            }

            return View(courseToEdit);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseToEdit = await _db.Courses
                    .FirstOrDefaultAsync(c => c.CourseId == id);

            if (courseToEdit == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(courseToEdit, "",
                c => c.CourseId, c => c.CourseName, c => c.ClassPlace1, c => c.ClassTime1,
                c => c.ClassPlace2, c => c.ClassTime2, c => c.CourseType, c => c.CourseCredit,
                c => c.CourseDescription, c => c.Week1, c => c.Week2, c => c.Week3, c => c.Week4, c => c.Week5,
                c => c.Week6, c => c.Week7, c => c.Week8, c => c.Week9, c => c.Week10, c => c.DepartmentID
                ))
            {
                try
                {
                    Console.WriteLine(courseToEdit);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }

            PopulateDepartmentsDropdownList(courseToEdit.DepartmentID);
            return View(courseToEdit);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var courseToDelete = await _db.Courses.FindAsync(id);

            try
            {
                _db.Courses.Remove(courseToDelete);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
            };

            return View(courseToDelete);
        }

        public void PopulateDepartmentsDropdownList(object selectedDepartment = null)
        {
            var departments = from d in _db.Departments
                              orderby d.DepartmentID
                              select d;
            ViewBag.DepartmentList = new SelectList(departments.AsNoTracking(), "DepartmentID", "DepartmentName", selectedDepartment);
        }
    }
}
