using System.Diagnostics;
using ContractMonthlyClaimsSystem_st10288567_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimsSystem_st10288567_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Controllers receive required services through dependency injection,
        // which improves maintainability and reduces coupling (Microsoft, 2024a).
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // IActionResult allows actions to return different response types such as Views, Redirects,
        // or HTTP status codes, making it flexible for MVC applications (Microsoft, 2024b).
        public IActionResult Index()
        {
            // Returns the default home page view.
            return View();
        }

        // It is considered best practice to use separate actions for static content pages
        // such as Policy or Privacy pages for clearer routing and organisation (Microsoft, 2024c).
        public IActionResult Privacy()
        {
            return View();
        }

        // This action handles error reporting by returning a view with diagnostic information.
        // Microsoft (2024d) recommends using the built-in error handling patterns together with ResponseCache
        // to ensure error pages are not cached for security and accuracy.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Generates an ErrorViewModel containing the request identifier for debugging.
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
