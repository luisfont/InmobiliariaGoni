﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using InmobiliariaGoni.API.ViewModels;
using Microsoft.AspNet.Identity;
using InmobiliariaGoni.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace InmobiliariaGoni.Website.Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<RealEstateUser> _signInManager;

        public AuthController(SignInManager<RealEstateUser> signInManager)
        {
            _signInManager = signInManager;
        }
        // GET: /<controller>/
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "App");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, false);

                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Houses", "App");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or password are invalid");
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "App");
        }
    }
}
