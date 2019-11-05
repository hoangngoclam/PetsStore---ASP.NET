using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class OrderDetailDao
    {
        PetAccessoriesShopDBContex db = null;
        public OrderDetailDao()
        {
            db = new PetAccessoriesShopDBContex();
        }
        public bool Insert(OrderDetail orderDetail)
        {
            try
            {
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }      
        }
        //admin
        public IEnumerable<OrderDetail> ListAll(string searchString, int page, int pagesize)
        {
            IOrderedQueryable<OrderDetail> model = db.OrderDetails;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(/*x => x.ProductID.ToString().Contains(searchString) ||*/ x=>x.OrderID.ToString().Contains(searchString)
                /*|| x.Quantity.ToString().Contains(searchString) || x.Price.ToString().Contains(searchString)*/).OrderBy(x => x.OrderID);
            }
            return model.OrderBy(x => x.OrderID).ToPagedList(page, pagesize);
        }
    }
}
