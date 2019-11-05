using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PetAccessoriesOnlineShop.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }
        
        public ActionResult ProductDetail(long productId)
        {
            var product = new ProductDao().ViewDetail(productId) ;
            return View(product);
        }
    }
}