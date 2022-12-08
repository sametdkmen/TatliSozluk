﻿using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class  //IRepositoryden değerleri al, şart olarak gönderilecek T değeri class olmalı.
    {
        Context c = new Context(); //Context sınıfından nesne üretiyoruz.

        DbSet<T> _object; // bu object T değerine karşılık gelen sınıfı tutacak.

        public GenericRepository()//Constructor 
        {
            _object = c.Set<T>();  // Yapıcı metod ile contexte bağlı olarak gönderilen T değerini objecte atıyoruz.
        }

        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);          // Entity State kullanarak crud işlemlerini yaptırdık.
            deletedEntity.State = EntityState.Deleted; 
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); // Bir dizide veya listede sadece bir değer döndürmek için singleordefault kullandık. yani sadece bir kişi için örnek olarak id'sini bulmak için.
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            // _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList(); // Geriye objectten gelen değerleri döndür listeleyerek dedik.
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); // Filterdan gelen değere göre bana listele.
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
