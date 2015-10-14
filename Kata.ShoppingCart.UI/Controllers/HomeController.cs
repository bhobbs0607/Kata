using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kata.ShoppingCart;

namespace Kata.ShoppingCart.UI.Controllers
{
    public class HomeController : Controller
    {
        //private List<SpecialPrice> _specials = new List<SpecialPrice>();
        //private ItemFinder _itemFinder = new ItemFinder();
        private Checkout _checkout;

        public HomeController()
        {
            var _specials = new List<SpecialPrice>();
            var _itemFinder = new ItemFinder();

            _itemFinder.Items.Add(new Item() { Name = "A", Price = 50, Sku = "A" });
            _itemFinder.Items.Add(new Item() { Name = "B", Price = 30, Sku = "B" });
            _itemFinder.Items.Add(new Item() { Name = "C", Price = 20, Sku = "C" });
            _itemFinder.Items.Add(new Item() { Name = "D", Price = 15, Sku = "D" });

            _specials.Add(new SpecialPrice() { ItemName = "A", ItemCount = 3, TotalAmount = 130 });
            _specials.Add(new SpecialPrice() { ItemName = "B", ItemCount = 2, TotalAmount = 45 });

            _checkout = new Checkout(_itemFinder, _specials);
        }

        [HttpGet]
        public ActionResult Index()
        {
            

            return View(CheckoutHolder.Checkout);
        }

        [HttpPost]
        public ActionResult Index(string sku)
        {
            // This isn't keeping the list up to date... Do to being stateless
            // Ran out of time to add in keeping a running list
            _checkout.Scan(sku);

            return View(_checkout);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}