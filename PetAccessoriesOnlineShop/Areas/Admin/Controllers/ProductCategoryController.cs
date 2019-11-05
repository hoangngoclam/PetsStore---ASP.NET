using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAccessoriesOnlineShop.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        // GET: Admin/ProductCategory
        public ActionResult Index(string searchString, int page = 1, int pagesize = 3)
        {
            var dao = new ProductCategoryDao();
            var model = dao.ListAll(searchString, page, pagesize);
            return View(model);
        }
    }
}