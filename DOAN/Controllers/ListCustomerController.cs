using DOAN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace DOAN.Controllers
{
    public class ListCustomerController : Controller
    {
        // GET: ListCustomer
        DoAnWebbEntities database = new DoAnWebbEntities();
        public ActionResult ListCustomer(string sdt)
        {
            if (sdt == null)
                return View(database.Customers.ToList());
            else
                return View(database.Customers.Where(s => s.SDT.Contains(sdt)).ToList());
        }
    }
}