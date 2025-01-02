using System.Diagnostics;
using BarsukTix.Models;
using BarsukTix.Services.DTO;
using BarsukTix.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace BarsukTix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly TicketService _ticketService;

		public HomeController(ILogger<HomeController> logger, TicketService ticketService)
        {
            _logger = logger;
			_ticketService = ticketService;
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

        [HttpPost]
		[Route("PaymentProcessing")]
		public IActionResult PaymentProcessing(PaymentProcessingData data)
		{
            var userId = User.Identity?.Name;
			_ticketService.PaymentProcessing(data);
			return View("Index");
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
