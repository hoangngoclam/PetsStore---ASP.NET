using Model.DAO;
using PetAccessoriesOnlineShop.Areas.Admin.Models;
using PetAccessoriesOnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAccessoriesOnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName,Encryptor.MD5Hash(model.Password));
                switch (result)
                {
                    case 1:
                        ModelState.AddModelError("", "Login seccess!");
                        var user = dao.GetByID(model.UserName);
                        var userSession = new UserLogin();
                        userSession.UserName = user.UserName;
                        userSession.UserID = user.ID;
                        Session.Add(CommonConstants.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Home");
                    case -2:
                        ModelState.AddModelError("", "Password's Fail!");
                        break;
                    case 0:
                        ModelState.AddModelError("", "Account isn't Exits!");
                        break;
                    case -1:
                        ModelState.AddModelError("", "Account isn't Active!");
                        break;             
                   
                    default:
                        ModelState.AddModelError("", "Error System!");
                        break;

                }
            }
            return View("Index");
           
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session[Common.CommonConstants.USER_SESSION] = null;
            return Redirect("/Admin/Login");
        }

    }
}