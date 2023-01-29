using Microsoft.AspNetCore.Mvc;
using Quotation.Models;

namespace Quotation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.DiscountAmount = "";
            ViewBag.FinalTotal = "";
            return View();
        }

        [HttpPost]
        public IActionResult Index(QuotationModel fv)
        {
            if (ModelState.IsValid)
            {
                // create culture variable
                var culture = System.Globalization.CultureInfo
                    .CreateSpecificCulture("en-US");

                ViewBag.DiscountAmount = fv.DiscountAmount().ToString("c2", culture);
                ViewBag.FinalTotal = fv.FinalTotal().ToString("c2", culture);
            }
            else
            {
                ViewBag.DiscountAmount = "";
                ViewBag.FinalTotal = "";
            }

            return View();
        }
    }
}