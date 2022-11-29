﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }



    }
    
    // ESKİ KODLAR 
        
        //GenericRepository<Category> repo = new GenericRepository<Category>();

        //public List<Category> GetAllBL() // Listeleme için Category tablosundakileri getirmek için metot oluşturdum.
        //{
        //    return repo.List();
        //}

        //public void CategoryAddBL(Category p) // Category sınıfından p parametresi gönderilecek.
        //{
        //    if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length >= 51)  // Şartlarımı, kısıtlamalarımı yazdım. 
        //    {
        //        //hata mesajı
        //    }
        //    else
        //    {
        //        repo.Insert(p);  // Yukarıda kısıtlamalara takılmayan girişler buradan eklenecek.
        //    }
        //}
}
