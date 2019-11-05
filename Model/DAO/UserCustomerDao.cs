using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class UserCustomerDao
    {
        PetAccessoriesShopDBContex db = null;
        public UserCustomerDao()
        {
            db = new PetAccessoriesShopDBContex();
        }

        public long Insert(UserCustomer entity)
        {
            db.UserCustomers.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool CheckUserName(string userName)
        {
            return db.UserCustomers.Count(x => x.UserName == userName) > 0;
        }

        public bool CheckUserEmail(string email)
        {
            return db.UserCustomers.Count(x => x.Email == email) > 0;
        }


        public UserCustomer GetByID(string userName)
        {
            return db.UserCustomers.SingleOrDefault(x => x.UserName == userName);
        }


        public int Login(string userName, string passWord)
        {
            var result = db.UserCustomers.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0; //tài khoản không tồn tại
            }
            else
            {
                if (result.Status == false)
                {
                    return -1; //tài khoản không hoạt động
                }
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1; // đăng nhập thành công
                    }
                    else
                    {
                        return -2; // mật khẩu không đúng
                    }
                }

            }
        }

        //Admin ->get list userCustomer
        public IEnumerable<UserCustomer> ListAll(string searchString, int page, int pagesize)
        {
            IOrderedQueryable<UserCustomer> model = db.UserCustomers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString)).OrderBy(x => x.ID);
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
    }
}
