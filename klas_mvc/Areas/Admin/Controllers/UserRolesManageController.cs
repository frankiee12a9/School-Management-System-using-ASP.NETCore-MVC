using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Models;
using ModelsLayer.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klas_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserRolesManageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesManageController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<string>> GetUserRoles(AppUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModel = new List<UserRoleViewModel>();
            foreach (AppUser user in users)
            {
                var currentViewModel = new UserRoleViewModel();
                currentViewModel.UserId = user.Id;
                currentViewModel.UserName = user.UserName;
                currentViewModel.Roles = await GetUserRoles(user);
                userViewModel.Add(currentViewModel);
            }

            return View(userViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} could not found.";
                return NotFound();
            }
            ViewBag.UserName = user.UserName;

            var model = new List<ManageRolesViewModel>();
            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRolesViewModel = new ManageRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelectedRole = true;
                }
                else
                {
                    userRolesViewModel.IsSelectedRole = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.IsSelectedRole).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
