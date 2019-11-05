using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAccessoriesOnlineShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            int pageIndex = 1;
            int pageSize = 5;
            int totalRecord = 0;
            ViewBag.ListNewProductAll = productDao.ListAllProduct(ref totalRecord, pageIndex, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.PageIndex = pageIndex;
            int maxPage = 5; //toi da bao nhieu trang
            int totalPage = (int)Math.Ceiling((double)(totalRecord/pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;
            return View();
        }
    }
}