using Model.DAO;
using Model.EF;
using PetAccessoriesOnlineShop.Common;
using PetAccessoriesOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAccessoriesOnlineShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session[Common.CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserCustomerDao();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "UserName Exits!");
                }
                else if (dao.CheckUserEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email Exits!");
                }
                else
                {
                    var user = new UserCustomer();
                    user.UserName = model.UserName;
                    user.Name = model.Name;
                    user.Password = Encryptor.MD5Hash(model.Password);
                    user.Phone = model.Phone;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    //user.Birthday = model.Birthday;
                    user.CreateDate = DateTime.Now;
                    user.Status = true;
                    var result = dao.Insert(user);
                    if (result>0)
                    {
                        ViewBag.Success = "Register success!";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Register fail!");
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserCustomerDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                switch (result)
                {
                    case 1:
                        ModelState.AddModelError("", "Login seccess!");
                        var user = dao.GetByID(model.UserName);
                        var userSession = new UserCustomerLogin();
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
            return View(model);
        }

    }
}