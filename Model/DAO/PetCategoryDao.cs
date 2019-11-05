using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class PetCategoryDao
    {
        PetAccessoriesShopDBContex db = null;
        public PetCategoryDao()
        {
            db = new PetAccessoriesShopDBContex();
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public Category ViewDetail(long id)
        {
            return db.Categories.Find(id);
        }

        //Admin
        public IEnumerable<Category> ListAll(string searchString, int page, int pagesize)
        {
            IOrderedQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString)).OrderBy(x => x.ID);
            }
            return model.OrderBy(x => x.CreateDate).ToPagedList(page, pagesize);
        }
    }
}
