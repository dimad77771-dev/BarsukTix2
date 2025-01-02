using System.Collections.Frozen;
using System.Diagnostics;
using BarsukTix.Models;
using BarsukTix.Services.DTO;
using BarsukTix.Services.Implementations;
using BarsukTix.Web.Utils;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Route("buyer")]
		public IActionResult Buyer()
		{
			return View();
		}

        [HttpPost]
        [Route("postTicket")]
        public IActionResult PostTicket()
        {
            var userId = this.GetUserId();
            var formdata = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            var viewmodel = _ticketService.PostTicket(formdata, userId);
            if (viewmodel is TicketViewModel)
            {
                return View("Ticket", viewmodel);
            }
            else if (viewmodel is BuyerViewModel)
            {
                return View("Buyer", viewmodel);
            }
            else throw new Exception();
        }


        [Route("ticket")]
		public IActionResult Ticket()
		{
            var userId = this.GetUserId();
            var viewmodel = _ticketService.GetTicketViewModel(userId);
            return View(viewmodel);
		}

		[Route("payment")]
		public IActionResult Payment()
		{
			return View();
		}

        //[Authorize]
        [HttpPost]
		[Route("PaymentProcessing")]
		public IActionResult PaymentProcessing(PaymentProcessingData data)
		{
            var userId = this.GetUserId();
            _ticketService.PaymentProcessing(data, userId);
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
