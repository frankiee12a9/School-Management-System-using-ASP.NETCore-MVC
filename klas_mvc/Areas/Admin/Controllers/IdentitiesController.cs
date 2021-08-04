using DataLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Models;
using ModelsLayer.Models.AccountModels;
using ModelsLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace klas_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IdentitiesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        public IdentitiesController(ApplicationDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            // get all users except current logged in user
            var allUsers = await _db.AppUsers.Where(u => u.Id != claims.Value).ToListAsync();
            if (allUsers == null)
            {
                return NotFound();
            }

            return View(allUsers);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _db.AppUsers.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            // get role of user
            var userRole = await _userManager.GetRolesAsync(user);

            PopulateDepartmentsDropdownList();

            if (userRole.First() == "Student")
            {
                // edit user is student 
                var studentToEdit = await _db.AppUsers
                    .Include(e => e.Enrollments)
                        .ThenInclude(c => c.Course)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (studentToEdit == null)
                {
                    return NotFound();
                }

                ViewData["Title"] = "Update Student";
                PopulateAssignedCourses(studentToEdit);
                return View(studentToEdit);
            }
            else
            {
                // edit user is lecturer
                var lecturerToEdit = await _db.AppUsers
                    .Include(ca => ca.CourseAssignments)
                        .ThenInclude(c => c.Course)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (lecturerToEdit == null)
                {
                    return NotFound();
                }

                ViewData["Title"] = "Update Lecturer";
                PopulateAssignedCourses(lecturerToEdit);
                return View(lecturerToEdit);
            }

            return View(user);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(string? id, string[] selectedCourses)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = await _db.AppUsers
                .FirstOrDefaultAsync(u => u.Id == id);

            if (currentUser == null)
            {
                return NotFound();
            }

            if (currentUser.UserType == "Student")
            {
                // NOTE: for HttpPost, in query if `AsNoTracking()` is included, then it will be persisted as read-only and 
                // can not use SaveChanges()
                var studentToEdit = await _db.AppUsers
                    .Include(e => e.Enrollments)
                        .ThenInclude(c => c.Course)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (await TryUpdateModelAsync(studentToEdit, "",
                    u => u.UserName, u => u.FirstName, u => u.LastName, u => u.Email,
                     u => u.PhoneNumber, u => u.UserType, u => u.DepartmentID))
                {
                    // update enrolled courses for students 
                    UpdateAssignedCourses(studentToEdit, selectedCourses);

                    try
                    {
                        Console.WriteLine(studentToEdit);
                        await _db.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        //Log the error (uncomment ex variable name and write a log.)
                        ModelState.AddModelError("", "Unable to save changes. " +
                            "Try again, and if the problem persists, " +
                            "see your system administrator.");
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                var lecturerToEdit = await _db.AppUsers
                    .Include(ca => ca.CourseAssignments)
                        .ThenInclude(c => c.Course)
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (await TryUpdateModelAsync(lecturerToEdit, "",
                 u => u.UserName, u => u.FirstName, u => u.LastName, u => u.Email,
                 u => u.PhoneNumber, u => u.UserType, u => u.DepartmentID))
                {
                    // update assigned courses 
                    UpdateAssignedCourses(lecturerToEdit, selectedCourses);

                    try
                    {

                        Console.WriteLine(lecturerToEdit);
                        await _db.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        //Log the error (uncomment ex variable name and write a log.)
                        ModelState.AddModelError("", "Unable to save changes. " +
                            "Try again, and if the problem persists, " +
                            "see your system administrator.");
                    }

                    return RedirectToAction(nameof(Index));
                }
            }

            UpdateAssignedCourses(currentUser, selectedCourses);
            PopulateDepartmentsDropdownList(currentUser.DepartmentID);
            return View(currentUser);
        }


        public void UpdateAssignedCourses(AppUser identity, string[] assignedCourses)
        {
            if (identity.UserType == "Student")
            {
                if (assignedCourses == null)
                {
                    identity.Enrollments = new List<Enrollment>();
                    return;
                }

                var selectedCoursesHS = new HashSet<string>(assignedCourses);
                var studentCourses = new HashSet<int>(identity.Enrollments.Select(c => c.Course.CourseId));
                foreach (var course in _db.Courses.ToList())
                {
                    if (selectedCoursesHS.Contains(course.CourseId.ToString()))
                    {
                        if (!studentCourses.Contains(course.CourseId))
                        {
                            identity.Enrollments.Add(new Enrollment { StudentId = identity.Id, CourseId = course.CourseId });
                            Console.WriteLine(identity.Enrollments);
                        }
                    }
                    else
                    {
                        if (studentCourses.Contains(course.CourseId))
                        {
                            var courseToReplace = identity.Enrollments.FirstOrDefault(c => c.CourseId == course.CourseId);
                            //  _db.CourseEnrollments.Remove(courseToReplace);  
                            _db.Remove(courseToReplace);
                        }
                    }

                    //  _db.SaveChanges();
                }

            }
            else
            {
                if (assignedCourses == null)
                {
                    identity.CourseAssignments = new List<CourseAssignment>();
                    return;
                }

                var selectedCoursesHS = new HashSet<string>(assignedCourses);
                var lecturerCourses = new HashSet<int>(identity.CourseAssignments.Select(c => c.Course.CourseId));
                foreach (var course in _db.Courses.ToList())
                {
                    if (selectedCoursesHS.Contains(course.CourseId.ToString()))
                    {
                        if (!lecturerCourses.Contains(course.CourseId))
                        {
                            identity.CourseAssignments.Add(new CourseAssignment { LecturerId = identity.Id, CourseId = course.CourseId });
                            Console.WriteLine(identity.CourseAssignments);
                        }
                    }
                    else
                    {
                        if (lecturerCourses.Contains(course.CourseId))
                        {
                            var courseToReplace = identity.CourseAssignments.FirstOrDefault(c => c.CourseId == course.CourseId);
                            //  _db.CourseCourseAssignmentss.Remove(courseToReplace);  
                            _db.Remove(courseToReplace);
                        }
                    }

                    // _db.SaveChanges();
                }
            }
        }

        public void PopulateAssignedCourses(AppUser identity)
        {
            var courses = _db.Courses.ToList();
            // if current identity is student
            if (identity.UserType == "Student")
            {
                var studentCourses = new HashSet<int>(identity.Enrollments.Select(c => c.CourseId));
                var coursesViewModel = new List<AssignedCoursesViewModel>();
                foreach (var course in courses)
                {
                    coursesViewModel.Add
                    (
                        new AssignedCoursesViewModel
                        {
                            CourseId = course.CourseId,
                            CourseName = course.CourseName,
                            isAssigned = studentCourses.Contains(course.CourseId)
                        }
                    );
                }

                ViewData["Courses"] = coursesViewModel;
            }
            else
            {
                // current identity is lecturer
                var lecturerCourses = new HashSet<int>(identity.CourseAssignments.Select(c => c.CourseId));
                var coursesViewModel = new List<AssignedCoursesViewModel>();
                foreach (var course in courses)
                {
                    coursesViewModel.Add
                    (
                        new AssignedCoursesViewModel
                        {
                            CourseId = course.CourseId,
                            CourseName = course.CourseName,
                            isAssigned = lecturerCourses.Contains(course.CourseId)
                        }
                    );
                }

                ViewData["Courses"] = coursesViewModel;
            }
        }

        public void PopulateDepartmentsDropdownList(object selectedDepartment = null)
        {
            var departments = from d in _db.Departments
                              orderby d.DepartmentID
                              select d;
            ViewBag.DepartmentList = new SelectList(departments.AsNoTracking(), "DepartmentID", "DepartmentName", selectedDepartment);
        }

        public async Task<IActionResult> LockUser(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToLock = await _db.AppUsers.FirstOrDefaultAsync(u => u.Id == id);
            if (userToLock == null)
            {
                return NotFound();
            }

            userToLock.LockoutEnd = DateTime.Now.AddYears(100);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UnlockUser(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToUnlock = await _db.AppUsers.FirstOrDefaultAsync(u => u.Id == id);
            if (userToUnlock == null)
            {
                return NotFound();
            }

            userToUnlock.LockoutEnd = DateTime.Now;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}