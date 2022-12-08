using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>             //Repository işlemleri için oluşan temel interface.
    {
        List<T> List();

        void Insert(T p);

        T Get(Expression<Func<T,bool>> filter); //sadece bir değer bulmak için (id) bu metodu tanımladık.

        void Delete(T p);

        void Update(T p);

        List<T> List(Expression<Func<T, bool>> filter); // Şartlı listeleme tanımladım.
    }
}


//