using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using PetAccessoriesOnlineShop.Common;

namespace PetAccessoriesOnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pagesize = 3)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pagesize);
            //Truyền model qua view, qua view thực hiện hiển thị các thành phần trong model
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long ID)
        {
            var user = new UserDao().ViewDetail(ID);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encrypedMD5Password = Encryptor.MD5Hash(user.Password);
                user.Password = encrypedMD5Password;
                user.CreateDate = DateTime.Now;
                user.CreateBy = "Admin";
                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Add User success!", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Add User is Fail!");
                }
            }
            return View("Index");
        }

    
        [HttpPost]
        public ActionResult Edit(User user)
        {
            
                var dao = new UserDao();
                if (user.Password !=null)
                {
                    var encrypedMD5Password = Encryptor.MD5Hash(user.Password);
                    user.Password = encrypedMD5Password;
                }             

                var result = dao.Update(user);

                if (result ==true)
                {
                    SetAlert("Edit User success!", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Update is Fail!");
                }
            
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int ID)
        {
            new UserDao().Delete(ID);
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
                                                 
    }
}