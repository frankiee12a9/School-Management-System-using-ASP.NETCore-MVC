using DataLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klas_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var departemnts = await _db.Departments.ToListAsync();
            return View(departemnts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await _db.Departments.AddAsync(department);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _db.Departments
                .Include(c => c.Courses)
                .FirstOrDefaultAsync(d => d.DepartmentID == id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            return View();
        }
    }
}
