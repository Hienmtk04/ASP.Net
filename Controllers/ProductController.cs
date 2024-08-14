using MaiThiKimHien_2122110261.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MaiThiKimHien_2122110261.Controllers
{
    public class ProductController : Controller
    {
        MaiThiKimHienEntities1 maiThiKimHienEntities1 = new MaiThiKimHienEntities1 ();

        public ActionResult Index(String searchString)
        {
            HomeModel model = new HomeModel();
            if (searchString != null) {
                model.ListProduct = maiThiKimHienEntities1.Products.Where(p => p.Name.Contains(searchString)).ToList(); 

            }
            else
            {
                model.ListProduct = maiThiKimHienEntities1.Products.ToList();

            }
            model.ListCategory = maiThiKimHienEntities1.Categories.ToList();
            model.ListBrand = maiThiKimHienEntities1.Brands.ToList();
            foreach (var brand in model.ListBrand)
            {
                brand.ProductCount = model.ListProduct.Count(p => p.Brand_id == brand.id);
            }
            return View(model);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = maiThiKimHienEntities1.Products.FirstOrDefault(p => p.Id == id);
            HomeModel model = new HomeModel();
            model.Product = product;
           
            
            return View(model);
        }
        public ActionResult Product_list_grid()
        {
            HomeModel model = new HomeModel();
            model.ListProduct = maiThiKimHienEntities1.Products.ToList();
            model.ListCategory = maiThiKimHienEntities1.Categories.ToList();
            model.ListBrand = maiThiKimHienEntities1.Brands.ToList();

            return View(model);
        }
        public ActionResult Product_list_large()
        {
            HomeModel model = new HomeModel();
            model.ListProduct = maiThiKimHienEntities1.Products.ToList();
            return View(model);
        }
        public ActionResult ProductByCategory(int id) { 
            HomeModel model = new HomeModel();
            model.ListCategory = maiThiKimHienEntities1.Categories.ToList();
            model.ListBrand = maiThiKimHienEntities1.Brands.ToList();
            model.ListProduct = maiThiKimHienEntities1.Products.Where(p => p.Category_id == id).ToList();
            
            return View(model);
        }
        public ActionResult ProductByBrand(int id)
        {
            HomeModel model = new HomeModel();
            model.ListCategory = maiThiKimHienEntities1.Categories.ToList();
            model.ListBrand = maiThiKimHienEntities1.Brands.ToList();
            model.ListProduct = maiThiKimHienEntities1.Products.Where(p => p.Brand_id == id).ToList();

            return View(model);
        }
        
    }
}