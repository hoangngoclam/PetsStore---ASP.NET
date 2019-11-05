using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAccessoriesOnlineShop.Areas.Admin.Controllers
{
    public class UserCustomerController : BaseController
    {
        // GET: Admin/UserCustomer
        public ActionResult Index(string searchString, int page = 1, int pagesize = 3)
        {
            var dao = new UserCustomerDao();
            var model = dao.ListAll(searchString, page, pagesize);
            //Truyền model qua view, qua view thực hiện hiển thị các thành phần trong model
            return View(model);
        }
    }
}