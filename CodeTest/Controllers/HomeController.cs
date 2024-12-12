using System;
using System.Linq;
using System.Web.Mvc;
using Quote.Contracts;
using Quote.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace PruebaIngreso.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuoteEngine quote;
        private readonly IMarginProvider marginProvider;
        private readonly MarginService marginService;

        public HomeController(IQuoteEngine quote, IMarginProvider marginProvider, MarginService marginService)
        {
            this.quote = quote;
            this.marginProvider = marginProvider;   
            this.marginService = marginService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            var request = new TourQuoteRequest
            {
                adults = 1,
                ArrivalDate = DateTime.Now.AddDays(1),
                DepartingDate = DateTime.Now.AddDays(2),
                getAllRates = true,
                GetQuotes = true,
                RetrieveOptions = new TourQuoteRequestOptions
                {
                    GetContracts = true,
                    GetCalculatedQuote = true,
                },
                TourCode = "E-U10-PRVPARKTRF",
                Language = Language.Spanish
            };

            var result = this.quote.Quote(request);
            var tour = result.Tours.FirstOrDefault();
            ViewBag.Message = "Test 1 Correcto";
            return View(tour);
        }

        public ActionResult Test2()
        {
            ViewBag.Message = "Test 2 Correcto";
            return View();
        }

        public async Task<ActionResult> Test3()
        {          

            ViewBag.ApiResponse = await this.marginService.GetMarginAsync("E-U10-UNILATIN");
            return View();
        }

        public async Task<ActionResult> Test4()
        {
            var request = new TourQuoteRequest
            {
                adults = 1,
                ArrivalDate = DateTime.Now.AddDays(1),
                DepartingDate = DateTime.Now.AddDays(2),
                getAllRates = true,
                GetQuotes = true,
                RetrieveOptions = new TourQuoteRequestOptions
                {
                    GetContracts = true,
                    GetCalculatedQuote = true,
                },
                Language = Language.Spanish
            };

            var result = this.quote.Quote(request);
            ViewBag.ApiResponse = await this.marginProvider.GetMarginAsync("E-U10-UNILATIN");
            return View(result.TourQuotes);
        }
    }
}