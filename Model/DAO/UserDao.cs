using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class UserDao
    {
        PetAccessoriesShopDBContex db = null;
        public UserDao()
        {
            db = new PetAccessoriesShopDBContex();
        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        
        //Admin ->get list user
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pagesize)
        {
            IOrderedQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString)).OrderBy(x => x.ID);
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }

        public  bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                if ( entity.Password !=null)
                {
                    user.Password = entity.Password;
                }
                if (entity.Name != null)
                {
                    user.Name = entity.Name;
                }
                if (entity.Address != null)
                {
                    user.Address = entity.Address;
                }
                if (entity.Email != null)
                {
                    user.Email = entity.Email;
                }             
                if (entity.Phone != null)
                {
                    user.Phone = entity.Phone;
                }
                user.Status = entity.Status;
                user.CreateDate = DateTime.Now;
                user.CreateBy = user.CreateBy;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //delete
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //Change status
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public User ViewDetail(long ID)
        {
            return db.Users.Find(ID);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result ==null)
            {
                return 0; //tài khoản không tồn tại
            }
            else
            {
                if (result.Status==false)
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

    }
}
