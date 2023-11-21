﻿using DOAN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using PagedList;
using PagedList.Mvc;
using System.Web.UI;

namespace DOAN.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DoAnWebbEntities database = new DoAnWebbEntities();
        //public ActionResult Index(string _name, int? page, double min = double.MinValue, double max = double.MaxValue)
        //{
        //    int pageSize = 4; // Số lượng sản phẩm mỗi trang
        //    int pageNumber = (page ?? 1); // Số trang hiện tại, mặc định là 1 nếu không có giá trị

        //    var products = string.IsNullOrEmpty(_name)
        //        ? database.Products.ToList()
        //        : database.Products.Where(s => s.TENSP.Contains(_name)).ToList();

        //    // Chuyển danh sách sản phẩm sang đối tượng PagedList
        //    var pagedList = new PagedList<Product>(products, pageNumber, pageSize, products.Count);

        //    return View(pagedList);
        //}

        public ActionResult Menu(string _name, int? page, double min = double.MinValue, double max = double.MaxValue)
        {
            

            if (_name == null)
                return View(database.Products.ToList());
            else
                return View(database.Products.Where(s => s.TENSP.Contains(_name)).ToList());
        }
        public ActionResult Index(string category, int? page, double min = double.MinValue, double max = double.MaxValue)
        {
            int pageSize = 4;
            int pageNum = (page ?? 1);
            if (category == null)
            {
                var productList = database.Products.OrderByDescending(x => x.TENSP);
                return View(productList.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var productList = database.Products.OrderByDescending(x => x.TENSP)
                    .Where(x => x.Category.TENLOAIHANG == category);
                return View(productList);
            }
        }

        public ActionResult Create()
        {
            Product pro = new Product();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            try
            {
                if (pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename = filename + extent;
                    pro.HINHSP = "~/Content/img/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), filename));
                }
                database.Products.Add(pro);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SelectCate()
        {
            Category se_cate = new Category();
            se_cate.ListCate = database.Categories.ToList<Category>();
            return PartialView(se_cate);
        }

        public ActionResult Edit(int id)
        {
            return View(database.Products.Where(s => s.MASP == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Product pro)
        {
            database.Entry(pro).State = EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(database.Products.Where(s => s.MASP == id ).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Product cate)
        {
            try
            {
                cate = database.Products.Where(s => s.MASP == id).FirstOrDefault();
                database.Products.Remove(cate);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
        public ActionResult Details(int id)
        {
            return View(database.Products.Where(s => s.MASP == id).FirstOrDefault());
        }
        public ActionResult ProductDetails(int id)
        {
            var relatedProducts = database.Products.Where(s => s.MASP == id).FirstOrDefault();
            var category = database.Products
                 .Where(p => p.MASP == id)
                 .Select(p => p.Category)
                 .FirstOrDefault();
            Session["category"] = category;
            return View(relatedProducts);
        }
        public PartialViewResult Recomment()
        {
            return PartialView(database.Products.ToList());
        }

        

    }
}