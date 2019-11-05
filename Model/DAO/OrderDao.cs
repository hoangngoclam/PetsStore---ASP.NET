using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class OrderDao
    {
        PetAccessoriesShopDBContex db = null;
        public OrderDao()
        {
            db = new PetAccessoriesShopDBContex();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }

        public IEnumerable<Order> ListAll(string searchString, int page, int pagesize)
        {
            IOrderedQueryable<Order> model = db.Orders;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipName.Contains(searchString) || x.ShipAddress.Contains(searchString)
                || x.ShipEmail.Contains(searchString) || x.ShipMobile.Contains(searchString)
                || x.ID.ToString().Contains(searchString) ).OrderBy(x => x.ID);
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
    }
}
