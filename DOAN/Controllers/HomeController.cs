using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult caphe()
        {
            return View();
        }
        public ActionResult Tra()
        {
            return View();
        }
        public ActionResult Trangorder()
        {
            return View();
        }
        public ActionResult Trangchu()
        {
            return View();
        }
       public ActionResult chititetsp()
        {
            return View();
        }
    }
}