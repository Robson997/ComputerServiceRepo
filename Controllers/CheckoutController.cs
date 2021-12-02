using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ComputerService.Models;
using ComputerService.Helpers;
using Stripe;

namespace ComputerService.Controllers
{
    public class CheckoutController : Controller
    {
        [TempData]
        public string TotalAmount { get; set; }
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ChosenItems>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.DollarAm = cart.Sum(ChosenItems => Convert.ToInt64(ChosenItems.Product.Price) * ChosenItems.Amount);
            ViewBag.total = ViewBag.DollarAm*100;
            ViewBag.total = Convert.ToInt64(ViewBag.total);
            long total = ViewBag.total;

            TotalAmount = total.ToString();

            return View();
        }
        [HttpPost]
        public IActionResult Processing(string stripeToken,string  stripeEmail)
        {
            var optionsCustumer = new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = "Robert",
                Phone = "123456789"
            };
            var serviceCustomer = new CustomerService();
            Customer customer = serviceCustomer.Create(optionsCustumer);
            var optionsCharge = new ChargeCreateOptions
            {
                Amount = Convert.ToInt64(TempData["TotalAmount"]),
                Currency = "USD",
                Description = "Selling Devices",
                Source = stripeToken,
                ReceiptEmail = stripeEmail
            };
            var serviceCharge = new ChargeService();
            Charge charge = serviceCharge.Create(optionsCharge);
            //if(charge.Status=="succeeded")
            //{
                ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount) / 100;
                ViewBag.Customer = customer.Name;

           // }
            return View();
        }
    }
}
