using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Models;
using ModelsLayer.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klas_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<AppUser> signManager, UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signManager = signManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    if (!await _roleManager.RoleExistsAsync(Helper.Helper.AdminRole))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Helper.Helper.AdminRole));
                    }

                    await _userManager.AddToRoleAsync(user, Helper.Helper.AdminRole);
                    // if not uncomment this line, after registered successfully, it will login automatically for current user
                    // await _signManager.SignInAsync(user, false);
                    return RedirectToAction("Login", "Account", new { area = "Admin"});
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe,
                    false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        // return RedirectToAction("Index");
                        return RedirectToAction(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin"});
                    }
                }
            }

            ModelState.AddModelError("", "Invalid login attemp.");
            return View(model);
        }

        // [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Login", "Account", new { area = "Admin" });
        }
    }
}
