using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductDao
    {
        PetAccessoriesShopDBContex db = null;
        public ProductDao()
        {
            db = new PetAccessoriesShopDBContex();
        }
        public List<Product> ListNewProduct(int top, int idCategoryProduct)
        {
            return db.Products.Where(x => x.CategoryProductID == idCategoryProduct).OrderByDescending(x=>x.CreateDate).Take(top).ToList();
        }

        public List<Product> ListAllProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

        public List<Product> ListNewProduct_IdPetCategory(int top, long PetCategoryId)
        {
            return db.Products.Where(x => x.CategoryID == PetCategoryId).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }


        //Phan trang

        public List<Product> ListNewProduct_IdPetCategory(int top, long PetCategoryId, int pageIndex, int pageSize)
        {
            return db.Products.Where(x => x.CategoryID == PetCategoryId).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<Product> ListAllProduct(ref int totalRecord,int pageIndex, int pageSize)
        {
            totalRecord = db.Products.Count();
            var model = db.Products.OrderByDescending(x => x.CreateDate).OrderBy(x=>x.CreateDate).Skip((pageSize-1)*pageIndex).Take(pageSize).ToList();
            return model;
        }


        //Admin
        public IEnumerable<Product> ListAll(string searchString, int page, int pagesize)
        {
            IOrderedQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Detail.Contains(searchString)).OrderBy(x => x.ID);
            }
            return model.OrderBy(x=>x.CreateDate).ToPagedList(page, pagesize);
        }


    }
}
