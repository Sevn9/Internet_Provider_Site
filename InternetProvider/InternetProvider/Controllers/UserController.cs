using InternetProvider.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;
using Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InternetProvider.Controllers
{
    public class UserController : Controller
    {
        private DbRepository _context { get; }

        public UserController(DbRepository context)
        {
            _context = context;
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Authorization()
        {
            return View();
        }

        [Authorize]
        public IActionResult PersonalPage()
        {
            var account = (Account) _context.GetItem(new Guid(User.Identity.Name), "Account");

            return View(account);
        }

        [HttpPost]
        public IActionResult Registration([FromForm] RegistrationForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            Account account = new Account
            {
                Id = Guid.NewGuid(),
                Name = form.Name,
                LastName = form.LastName,
                Patronymic = form.Patronymic,
                Email = form.Email,
                City = form.City,
                PhoneNumber = form.PhoneNumber,
                Password = Suffer.HashPassword(form.Password),
                Role = "Admin"
            };

            _context.Create(account);

            return Redirect("http://localhost:59457");
        }

        [HttpPost]
        public async Task<IActionResult> AuthorizationAsync([FromForm] AuthorizationForm authorization)
        {
            if (!ModelState.IsValid)
                return View(authorization);
            Account account;
            if (Regex.IsMatch(authorization.LoginKey, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                account = _context.GetAccountByEmail(authorization.LoginKey);
            else
                account = _context.GetAccountByPhoneNumber(authorization.LoginKey);
            if (account != null)
            {
                if (Suffer.IsVerified(account.Password, authorization.Password))
                {
                    await Authenticate(account.Id.ToString(), account.Role, authorization.RememberMe);

                    return Redirect("http://localhost:59457");
                }
            }
                ModelState.AddModelError("", "Некорректный логин или пароль");
                return View(authorization);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("http://localhost:59457");
        }

        private async Task Authenticate(string userName, string userRole, bool isPersistent)
        {
            var claims = new List<Claim>{
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            var authProperties = new AuthenticationProperties();
            if (isPersistent)
                authProperties.IsPersistent = true;
            else
                authProperties.IsPersistent = false;
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id), authProperties);
        }
    }
}
