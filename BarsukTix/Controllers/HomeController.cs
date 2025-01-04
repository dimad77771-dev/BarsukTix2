using System.Collections.Frozen;
using System.Diagnostics;
using BarsukTix.Data.Entities;
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

        [HttpPost]
        [Route("ticket")]
        public IActionResult PostTicket()
        {
            var userId = this.GetUserId();
            var formdata = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            var viewmodel = _ticketService.PostTicket(formdata, userId);
            if (viewmodel.HasError)
            {
                return View("Ticket", viewmodel);
            }
            else
            {
                return Redirect("Buyer");
            }
        }

        [HttpGet]
        [Route("Ticket")]
		public IActionResult Ticket()
		{
            var userId = this.GetUserId();
            var viewmodel = _ticketService.GetTicketViewModel(userId);
            return View(viewmodel);
		}

        [HttpGet]
        [Route("Buyer")]
        public IActionResult Buyer()
        {
            var userId = this.GetUserId();
            var viewmodel = _ticketService.GetTicketViewModel(userId);
            return View(viewmodel);
        }

        [HttpPost]
        [Route("buyer")]
        public IActionResult PostBuyer(Ticket ticketdata)
        {
            var userId = this.GetUserId();
            var formdata = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            var viewmodel = _ticketService.PostBuyer(ticketdata, formdata, userId);
            if (viewmodel.Ticket.IsReadyPayment && !viewmodel.Ticket.IsPaid)
            {
                return Redirect("payment");
            }
            else
            {
                return View("buyer", viewmodel);
            }
		}

        [Route("payment")]
		public IActionResult Payment()
		{
			var userId = this.GetUserId();
			var viewmodel = _ticketService.GetTicketViewModel(userId);
			return View("payment", viewmodel);
		}

        //[Authorize]
        [HttpPost]
		[Route("PaymentProcessing")]
		public IActionResult PaymentProcessing(PaymentProcessingData data)
		{
            var userId = this.GetUserId();
			var viewmodel = _ticketService.PaymentProcessing(data, userId);
            if (viewmodel.HasError)
            {
				return View("payment", viewmodel);
			}
            else
            {
			    return View("Index");
            }
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
