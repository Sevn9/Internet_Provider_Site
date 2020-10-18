using InternetProvider.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;
using Security;
using System;

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

        [HttpPost]
        public IActionResult Registration([Bind("Name, LastName, Patronymic, City, Email, PhoneNumber, Password, ConfirmPassword")] RegistrationForm form)
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
                Role = null
            };

            _context.Create(account);

            return Redirect("http://localhost:59457");
        }
    }
}
