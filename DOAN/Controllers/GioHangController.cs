using DOAN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace DOAN.Controllers
{
    public class GioHangController : Controller
    {
        DoAnWebbEntities database = new DoAnWebbEntities();
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
                return View("EmptyCart");
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            var _pro = database.Products.SingleOrDefault(s => s.MASP == id);
            if (_pro != null)
            {
                GetCart().Add_Product_Cart(_pro);
            }
            return RedirectToAction("ShowCart", "GioHang");
        }
        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["idPro"]);
            int _quantity = int.Parse(form["cartQuantity"]);
            cart.Update_quantity(id_pro, _quantity);
            return RedirectToAction("ShowCart", "GioHang");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public PartialViewResult BagCart()
        {
            int toltal_quantity_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                toltal_quantity_item = cart.Total_quantity();
            ViewBag.QuantityCart = toltal_quantity_item;
            return PartialView("BagCart");
        }

        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                OrderPro _order = new OrderPro(); //Bảng Hóa Đơn Sản Phẩm
                _order.NGAYDAT = DateTime.Now;
                _order.DIACHIGIAOHANG = form["AddressDelivery"];
                _order.MAKH = int.Parse(form["CodeCustomer"]);
                database.OrderProes.Add(_order);
                foreach (var item in cart.Items)
                {
                    OrderDetail _order_detail = new OrderDetail(); //Lưu dòng sản phẩm vào bảng chi tiết hóa đơn 
                    _order_detail.MACHITIET = _order.MADATHANG;
                    _order_detail.MACHITIET = item._product.MASP;
                    _order_detail.Tongtien = (double)item._product.GIa;
                    _order_detail.SOLUONG = item._quantity;
                    database.OrderDetails.Add(_order_detail);
                    //xử lý cập nhật lại số lượng tồn trong bảng Product
                    //foreach (var p in database.Products.Where(s => s.MASP == _order_detail.MACHITIET))
                    //{
                    //    var update_quan_pro = p.s - item._quantity; //số lượng tồn mới = số lượng tồn - số lượng đã mua
                    //    p.Quantity = update_quan_pro; //thực hiện cập nhật lại sô lượng tồn cho cột Quantity của bảng Product
                    //}
                }
                database.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("CheckOut_Success", "GioHang");
            }
            catch
            {
                return Content("Error checkout. Please check information of Customer...Thanks.");
            }
        }

        public ActionResult CheckOut_Success()
        {
            return View();
        }
    }
}