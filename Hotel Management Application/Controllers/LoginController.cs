﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementApplication.Models.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model, string returnUrl = null)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var result = await _signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    model.RememberMe,
                    false
                );

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Login error!");
                    return RedirectToAction(nameof(Index));
                }

                if (string.IsNullOrWhiteSpace(returnUrl))
                    return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }

            return Redirect(returnUrl);
        }
    }
}