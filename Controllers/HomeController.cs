using MaiThiKimHien_2122110261.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiThiKimHien_2122110261.Controllers
{
    public class HomeController : Controller
    {
        MaiThiKimHienEntities1 objProductEntities = new MaiThiKimHienEntities1();
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.ListProduct = objProductEntities.Products.ToList();
            model.ListCategory = objProductEntities.Categories.ToList();
            model.ListBrand = objProductEntities.Brands.ToList();
            model.ListBanner = objProductEntities.Banners.ToList();
            return View(model);
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