using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PetAccessoriesOnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Pet Category",
                url: "product/{metatitle}-{petCategoryId}",
                defaults: new { controller = "PetCategory", action = "CategoryUrl", id = UrlParameter.Optional },
                namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
            );

            routes.MapRoute(
            name: "Product Detail",
            url: "product-detail/{metatitle}-{productId}",
            defaults: new { controller = "ProductCategory", action = "ProductDetail", id = UrlParameter.Optional },
            namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
            );

            routes.MapRoute(
            name: "About",
            url: "about",
            defaults: new { controller = "About", action = "index", id = UrlParameter.Optional },
            namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
            );

            routes.MapRoute(
             name: "Feedback",
             url: "feedback",
             defaults: new { controller = "Feedback", action = "index", id = UrlParameter.Optional },
             namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
             );

            routes.MapRoute(
             name: "Contact",
             url: "contact",
             defaults: new { controller = "Contact", action = "index", id = UrlParameter.Optional },
             namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
             );

            routes.MapRoute(
              name: "Shop",
              url: "shop",
              defaults: new { controller = "Shop", action = "index", id = UrlParameter.Optional },
              namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
              );

            routes.MapRoute(
              name: "Category",
              url: "category",
              defaults: new { controller = "Category", action = "index", id = UrlParameter.Optional },
              namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
              );


            routes.MapRoute(
              name: "Add Cart",
              url: "cart-item",
              defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
              namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
              );

            routes.MapRoute(
              name: "Payment",
              url: "payment",
              defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
              namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
              );

            routes.MapRoute(
              name: "Payment Success",
              url: "success",
              defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
              namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
              );

            routes.MapRoute(
              name: "Register",
              url: "register",
              defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
              namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
              );

            routes.MapRoute(
              name: "Login",
              url: "login",
              defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
              namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
              );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "PetAccessoriesOnlineShop.Controllers" }
            );
        }
    }
}
