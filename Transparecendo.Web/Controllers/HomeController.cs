using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Transparecendo.Application.Web.Models;
using Transparecendo.Service.Web.Services;
using Transparecendo.Service.Web.Services.Interfaces;

namespace Transparecendo.Application.Web.Controllers
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
            var result = await _corporateSpendingService.GetByData(DateTime.Now, DateTime.Now);
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