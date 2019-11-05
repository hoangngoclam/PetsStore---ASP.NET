using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductCategoryDao
    {
        PetAccessoriesShopDBContex db = null;
        public ProductCategoryDao()
        {
            db = new PetAccessoriesShopDBContex();
        }
        public List<CategoryProduct> ListAll()
        {
            return db.CategoryProducts.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        //Admin
        public IEnumerable<CategoryProduct> ListAll(string searchString, int page, int pagesize)
        {
            IOrderedQueryable<CategoryProduct> model = db.CategoryProducts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString)).OrderBy(x => x.ID);
            }
            return model.OrderBy(x => x.CreateDate).ToPagedList(page, pagesize);
        }
    }
}
