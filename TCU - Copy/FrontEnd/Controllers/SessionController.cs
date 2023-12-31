﻿using bend.bil;
using bend.dal.entities;
using fend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace fend.Controllers
{
    public class SessionController : Controller
    {
        ResetViewModel ForgotPassword { get; set; }

        public SessionController()
        {
            ForgotPassword = new ResetViewModel();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(Users user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IUserSession session = new UserSession();

                    if (session.Exist(user))
                        return RedirectToAction(nameof(AlreadyRegistered));

                    await session.SignUp(user);

                    TempData["Message"] = "El registro se realizó correctamente, por favor inicie sesión.";

                    return RedirectToAction(nameof(Login));
                }
            }
            catch
            {
                throw;
            }

            return View();
        }

        public IActionResult AlreadyRegistered()
        {
            return View();
        }

        public IActionResult AccessError() 
        {
            return View(); 
        }

        public IActionResult PasswordResetError()
        {
            return View();
        }

        public IActionResult PasswordReset()
        {
            var reset = new ResetViewModel();

            return View(reset);
        }

        [HttpPost]
        public async Task<IActionResult> PasswordReset(ResetViewModel reset)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (reset.VerificationCode != reset.CodeConfirmation)
                        return RedirectToAction(nameof(PasswordResetError));

                    IUserSession session = new UserSession();
                    bool pwdResetSuccessful = await session.ResetPasswordFor(reset.Username, reset.Password);

                    if (!pwdResetSuccessful)
                        return RedirectToAction(nameof(PasswordResetError));

                    TempData["Message"] = "La contraseña se cambió exitosamente. Por favor inicie sesión.";

                    return RedirectToAction(nameof(Login));
                }
            }
            catch
            {
                throw;
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Users user)
        {
            try
            {
                IUserSession session = new UserSession();
                Users _user = session.Authenticate(user);

                if (_user == null)
                    return RedirectToAction(nameof(AccessError));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(session.SetIdentityFor(_user)));

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
