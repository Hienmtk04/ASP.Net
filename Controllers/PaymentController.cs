using MaiThiKimHien_2122110261.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiThiKimHien_2122110261.Controllers
{
    public class PaymentController : Controller
    {
        MaiThiKimHienEntities1 objMaiThiKimHienEntities = new MaiThiKimHienEntities1();
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "User");

            }
            else
            {
                var listProduct = (List<CartModel>)Session["cart"];
                Order objOrder = new Order();
                objOrder.Name = "Đơn hàng - " + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objMaiThiKimHienEntities.Orders.Add(objOrder);
                objMaiThiKimHienEntities.SaveChanges();

                int orderId = objOrder.Id;
                List<OrderDetail> orderDetail = new List<OrderDetail>();
                foreach (var item in listProduct)
                {
                    OrderDetail objOrderDetail = new OrderDetail();
                    objOrderDetail.Quantity = item.Quantity;
                    objOrderDetail.OrderId = orderId;
                    objOrderDetail.ProductId = item.Product.Id;
                    orderDetail.Add(objOrderDetail);
                }
                objMaiThiKimHienEntities.OrderDetails.AddRange(orderDetail);
                objMaiThiKimHienEntities.SaveChanges();
            }
            return View();

        }
    }
}