using System.Diagnostics;
using BarsukTix.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarsukTix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("Venue")]
        public IActionResult Venue()
        {
            return View();
        }

        [Route("Buy")]
        public IActionResult Buy()
        {
            return View();
        }

		[Route("buyer")]
		public IActionResult Buyer()
		{
			return View();
		}

		[Route("ticket")]
		public IActionResult Ticket()
		{
			return View();
		}

		[Route("payment")]
		public IActionResult Payment()
		{
			return View();
		}


		[Route("zzFullTestPage")]
        public IActionResult zzFullTestPage()
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
