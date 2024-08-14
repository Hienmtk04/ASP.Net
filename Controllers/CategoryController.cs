using MaiThiKimHien_2122110261.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiThiKimHien_2122110261.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MaiThiKimHienEntities1 objCategoryEntities = new MaiThiKimHienEntities1();
        public ActionResult Category()
        {
            HomeModel homeModel = new HomeModel();
            homeModel.ListCategory = objCategoryEntities.Categories.ToList();
            return View(homeModel);
        }
        
    }
}