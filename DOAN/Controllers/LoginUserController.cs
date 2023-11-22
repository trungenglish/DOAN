using DOAN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN.Controllers
{
    public class LoginUserController : Controller
    {
        DoAnWebbEntities database = new DoAnWebbEntities();

        // GET: LoginUser
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer user)
        {
            var check = database.Customers.Where(s => s.SDT == user.SDT && s.PASSWORD == user.PASSWORD).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErroInfo = "Sai thông tin đăng nhập";
                return View("Login");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["SDT"] = user.SDT;
                Session["Password"] = user.PASSWORD;
                return RedirectToAction("Trangchu","Home");
            }
            
        }
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(Customer user)
        {
            if (ModelState.IsValid)
            {
                var check = database.Customers.Where(s => s.SDT == user.SDT).FirstOrDefault();
                if (check == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.Customers.Add(user);
                    database.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.ErrorRegister = "Tài khoản này đã tồn tại";
                    return View();
                }
            }
            return View();
        }
       

        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(Customer cus)
        //{
        //    cus.MAKH = GenerateRandomID();
        //    database.Customers.Add(cus);
        //    database.SaveChanges();
        //    return RedirectToAction("ShowCart", "GioHang");
        //}

        //private int GenerateRandomID()
        //{
        //    Random rand = new Random();
        //    int randomID = rand.Next(1000, 9999);
        //    return randomID;
        //}
        //    public ActionResult ADDTOLAYOUT()
        //    {
        //        string randomCode = GenerateRandomCode();
        //        ViewBag.randomCode = randomCode;

        //        return View();
        //    }
        //    private string GenerateRandomCode()
        //    {
        //        Sinh mã xác nhận ngẫu nhiên, ví dụ đơn giản là một chuỗi số 4 chữ số
        //        return new Random().Next(1000, 9999).ToString();
        //    }
        //    public ActionResult Login()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    public ActionResult GenerateVerificationCode(string phoneNumber)
        //    {
        //        string verificationCode = GenerateRandomCode();
        //        Lưu mã xác nhận và số điện thoại vào Session để kiểm tra sau này
        //       Session["VerificationCode"] = verificationCode;
        //        Session["PhoneNumber"] = phoneNumber;

        //        return Json(new { code = verificationCode });
        //    }
        //    [HttpPost]
        //    public ActionResult VerifyCode(string enteredCode)
        //    {
        //        string storedCode = Session["VerificationCode"] as string;
        //        string phoneNumber = Session["PhoneNumber"] as string;

        //        if (enteredCode == storedCode)
        //        {
        //            Đăng nhập thành công, lưu số điện thoại vào cơ sở dữ liệu
        //            SavePhoneNumberToDatabase(phoneNumber);
        //            Xóa thông tin từ Session sau khi xác nhận mã
        //            Session.Remove("VerificationCode");
        //            Session.Remove("PhoneNumber");

        //            return Json(new { success = true });
        //        }
        //        else
        //        {
        //            return Json(new { success = false, message = "Mã xác nhận không đúng. Vui lòng thử lại." });
        //        }
        //    }

        //    private void SavePhoneNumberToDatabase(string phoneNumber)
        //    {
        //        Kiểm tra xem số điện thoại đã tồn tại trong cơ sở dữ liệu hay chưa
        //        var existingCustomer = database.Customers.FirstOrDefault(c => c.SDT == phoneNumber);

        //        if (existingCustomer == null)
        //        {
        //            Nếu số điện thoại chưa tồn tại, thêm mới vào cơ sở dữ liệu
        //           var customer = new Customer { SDT = phoneNumber };
        //            database.Customers.Add(customer);
        //            database.SaveChanges();
        //        }
        //        Nếu số điện thoại đã tồn tại, bạn có thể không thực hiện thêm mới
        //    }

        //}
    }
}
    