using Model.DAO;
using Model.EF;
using PetAccessoriesOnlineShop.Common;
using PetAccessoriesOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PetAccessoriesOnlineShop.Controllers
{
    public class CartController : Controller
    {
        
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart !=null)
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }
       
        public ActionResult AddItem(long productID, int quantity)
        {

            var product = new ProductDao().ViewDetail(productID);

            var cart = Session[CommonConstants.CartSession];

            if (cart != null)
            {
                var list = (List<CartItem>)cart;

                //Neu trong danh sach co chua ma san pham do
                if (list.Exists(x => x.Product.ID == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //Tao moi doi tuong cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }

            }
            else
            {
                //Tao moi doi tuong cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gan vao session
                Session[CommonConstants.CartSession] = list;
            }



            return RedirectToAction("Index");
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];

            sessionCart.RemoveAll(x => x.Product.ID == id);

            Session[CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[CommonConstants.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult Payment()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string name, string address, string mobile,string email)
        {
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.ShipName = name;
            order.ShipAddress = address;
            order.ShipMobile = mobile;
            order.ShipEmail = email;
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CommonConstants.CartSession];
                var detailDao = new OrderDetailDao();
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.ProductName = item.Product.Name;
                    orderDetail.SubTotalProduct = (item.Quantity)*(item.Product.Price);

                    detailDao.Insert(orderDetail);
                }
            }
            catch (Exception)
            {
                return Redirect("/erro-payment");
            }
            return Redirect("/success");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}