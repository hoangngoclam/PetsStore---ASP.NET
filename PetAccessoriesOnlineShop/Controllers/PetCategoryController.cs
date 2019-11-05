using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAccessoriesOnlineShop.Controllers
{
    public class PetCategoryController : Controller
    {
        // GET: PetCategory
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult PetCategory()
        {
            var model = new PetCategoryDao().ListAll();
            return PartialView(model);
        }

        public ActionResult CategoryUrl(long petCategoryId)
        {

            var productDao = new ProductDao();
            ViewBag.ListNewProduct_PetCategory = productDao.ListNewProduct_IdPetCategory(100, petCategoryId);
            var petCategory = new PetCategoryDao().ViewDetail(petCategoryId);
            return View(petCategory);
        }
    }
}