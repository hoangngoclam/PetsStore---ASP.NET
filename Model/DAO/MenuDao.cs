﻿using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    
    public class MenuDao
    {
        PetAccessoriesShopDBContex db = null;
        public MenuDao()
        {
            db = new PetAccessoriesShopDBContex();
        }
        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId).OrderBy(x=>x.DisplayOrder).ToList();
        } 
       
    }
}
