using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();  // context sınıfından c adında nesne türettik.
        DbSet<Category> _object;   // DbSet türünde Category sınıfından referans oluşturdum.

        public void Delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(Category p)
        {
            _object.Add(p);
            c.SaveChanges(); // Ado-Net karşılığı ExecuteNonQuery olan komut. değişiklikleri kaydet anlamında.
        }

        public List<Category> List()
        {
            return _object.ToList();  // Category sınıfından gelen değerleri listelettirme metodunu yazdık.
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            c.SaveChanges();
        }
    }

    /*
    ToList
    Add
    Remove
    Find
     */
}
