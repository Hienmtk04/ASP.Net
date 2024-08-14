using MaiThiKimHien_2122110261.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiThiKimHien_2122110261.Areas.Admin.Controllers
{
    public class AdminProductController : Controller
    {
        MaiThiKimHienEntities1 dbObj = new MaiThiKimHienEntities1();
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.ListProduct = dbObj.Products.ToList();
            model.ListCategory = dbObj.Categories.ToList();
            model.ListBrand = dbObj.Brands.ToList();

            return View(model);
        }
    }
}