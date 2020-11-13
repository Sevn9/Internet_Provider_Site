using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace InternetProvider.Controllers
{
    public class TariffController : Controller
    {
        private DbRepository _context { get; }

        public TariffController(DbRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TariffList()
        {
            var tariffs = _context.GetItemList("TariffPlan");



            if (tariffs != null)
                return View(tariffs);
            return View();
        }
        public IActionResult TariffDetails(Guid id)
        {
            var tariff = (TariffPlan)_context.GetItem(id, "TariffPlan");

            var reviews = _context.GetReviewList(id);
            tariff.Reviews = reviews;

            return View(tariff);
        }
    }
}
