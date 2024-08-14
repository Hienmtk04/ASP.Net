using MaiThiKimHien_2122110261.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MaiThiKimHien_2122110261.Controllers
{
    public class CartController : Controller
    {
        MaiThiKimHienEntities1 objMaiThiKimHienEntities = new MaiThiKimHienEntities1();
        public ActionResult Shopping_cart()
        {
            HomeModel homeModel = new HomeModel();
            homeModel.Cart = (List<CartModel>)Session["cart"];
            return View(homeModel);
        }
        public ActionResult AddToCart(int id, int quantity)
        {
            if (Session["cart"] == null)
            {
                List<CartModel> cart = new List<CartModel>();
                cart.Add(new CartModel { Product = objMaiThiKimHienEntities.Products.Find(id), Quantity = quantity });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity += quantity;
                }
                else
                {
                    cart.Add(new CartModel { Product = objMaiThiKimHienEntities.Products.Find(id), Quantity = quantity });
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }
            return Json(new { Message = "Thành công!", JsonRequestBehavior.AllowGet });
        }

        private int isExist(int id)
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;

        }

        public ActionResult Remove(int Id)
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            cart.RemoveAll(x => x.Product.Id == Id);
           
            Session["cart"] = cart; 
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            double totalAmount = cart.Sum(x =>
            (x.Product.PriceSale > 0 ? x.Product.PriceSale : x.Product.Price) * x.Quantity);

            return Json(new
            {
                Message = "Xóa sản phẩm thành công!",
                TotalAmount = totalAmount,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            });
        }

        public ActionResult UpdateCart(int id, int quantity)
        {
            List<CartModel> listCart = (List<CartModel>)Session["cart"];
            CartModel cart = listCart.FirstOrDefault(n => n.Product.Id == id);
            double totalPrice = 0;
            if (cart != null)
            {
                cart.Quantity = quantity;
            }
            if (cart.Product.PriceSale > 0) {
                totalPrice += cart.Product.PriceSale * quantity;
            }
            else
            {
                totalPrice += cart.Product.Price * quantity;
            }
            Session["cart"] = listCart;
            return Json(new
            {
                Message = "Cập nhật thành công!",
                TotalPrice = totalPrice.ToString("C", new System.Globalization.CultureInfo("vi-VN")),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            });
        }
    }
}