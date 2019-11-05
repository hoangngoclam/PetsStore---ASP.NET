using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAccessoriesOnlineShop.Areas.Admin.Controllers
{
    public class OrderDetailController : BaseController
    {
        // GET: Admin/OrderDetail
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new OrderDetailDao();
            var model = dao.ListAll(searchString, page, pagesize);
            return View(model);
        }
    }
}