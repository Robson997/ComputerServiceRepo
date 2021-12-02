
using ComputerService.Helpers;
using ComputerService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerService.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ChosenItems>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(ChosenItems => Convert.ToInt32(ChosenItems.Product.Price) * ChosenItems.Amount);

            return View();
        }
        private int isExist(string id)
        {
            List<ChosenItems> cart = SessionHelper.GetObjectFromJson<List<ChosenItems>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if(cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult Buy(string id)
        {
            AllItems allitems = new AllItems();
            if(SessionHelper.GetObjectFromJson<List<ChosenItems>>(HttpContext.Session,"cart")==null)
                {
                List<ChosenItems> cart = new List<ChosenItems>();
                cart.Add(new ChosenItems { Product = allitems.find(id), Amount = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<ChosenItems> cart = SessionHelper.GetObjectFromJson<List<ChosenItems>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if( index != -1)
                {
                    cart[index].Amount++;
                }
                else
                {
                    cart.Add(new ChosenItems { Product = allitems.find(id), Amount = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }


        public IActionResult Remove(string id)
        {
            List<ChosenItems> cart = SessionHelper.GetObjectFromJson<List<ChosenItems>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }


    }
}
