using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using Transparecendo.Web.Models;
using Transparecendo.Web.Services.Interfaces;

namespace Transparecendo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICorporateSpendingService _corporateSpendingService;

        public HomeController(ILogger<HomeController> logger, ICorporateSpendingService corporateSpendingService)
        {
            _corporateSpendingService = corporateSpendingService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var allExpenseByTerm = await _corporateSpendingService.GetAllExpenseByTerm();
            ViewBag.ExpenseByTerm = allExpenseByTerm.OrderBy(a => a.Ordem).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}