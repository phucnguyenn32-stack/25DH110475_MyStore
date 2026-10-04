using _25DH110475_MyStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace _25DH110475_MyStore.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (MystoreEntities db = new MystoreEntities())
            {
                ViewBag.CategoryCount = db.Categories.Count();
                ViewBag.ProductCount = db.Products.Count();
                ViewBag.CustomerCount = db.Customers.Count();
                ViewBag.OrderCount = db.Orders.Count();
            }

            return View();
        }
    }
}