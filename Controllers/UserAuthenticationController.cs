﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegLog.Models.DTO;
using RegLog.Repositories.Abstract;

namespace RegLog.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this._authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Display", "Dashboard");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            model.Role = "user";
            var result = await this._authService.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this._authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
        //public async Task<IActionResult> reg()
        //{
        //    var model = new RegistrationModel
        //    {
        //        Username = "pidar",
        //        Name = "Denis",
        //        Email = "den90021@gmail.com",
        //        Password = "Admin@12345#"
        //    };
        //    model.Role = "admin";
        //    var result = await this._authService.RegistrationAsync(model);
        //    return Ok(result);
        //}
    }
}
