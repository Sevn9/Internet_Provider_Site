using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace InternetProvider.Controllers
{
    public class AdminController : Controller
    {
        private DbRepository _context { get; }

        public AdminController(DbRepository context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditUser(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = (Account)_context.GetItem(id, "Account");

            return View(account);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditUser(Guid id, [FromForm] Account account)
        {
            var routeAccount = (Account)_context.GetItem(id, "Account");

            var resultAccount = new Account()
            {
                Id = routeAccount.Id,
                Name = account.Name,
                LastName = account.LastName,
                Patronymic = account.Patronymic,
                City = account.City,
                Role = account.Role,

                Email = routeAccount.Email,
                Password = routeAccount.Password,
                PhoneNumber = routeAccount.PhoneNumber,
                ServiceId = routeAccount.ServiceId,
                TariffPlanId = routeAccount.TariffPlanId
            };

            _context.Update(resultAccount);

            return View("UserList");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult UserList(string searchString, string role)
        {

            var accounts = (IEnumerable<Account>)_context.GetItemList("Account");

            if (!string.IsNullOrEmpty(searchString))
            {
                accounts = accounts.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(role))
            {
                accounts = accounts.Where(s => s.Role.Contains(role));
            }

            if (accounts != null)
                return View(accounts);
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateTariff()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateTariff([FromForm] TariffPlan tariffPlan)
        {
            tariffPlan.Id = Guid.NewGuid();
            _context.Create(tariffPlan);

            return View();
        }
    }
}
