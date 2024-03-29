using DataAccessLayer.Context;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repostory
{
    public class GenericRepoDAL<T> : IGenericDAL<T> where T : class
    {
        BlogDBContext db = new BlogDBContext();

        //public GenericRepoDAL()
        //{
        //    db = new BlogDBContext();
        //}

        public void add(T t)
        {
            db.Add(t);
            db.SaveChanges();
        }
        public void addRange(List<T> t1)
        {
            db.AddRange(t1);
            db.SaveChanges();
        }
        public void remove(T t)
        {
            db.Remove(t);
            db.SaveChanges();

        }
        public void removeRange(List<T> t1)
        {
            db.RemoveRange(t1); db.SaveChanges();
        }
        public void update(T t)
        {
            db.Update(t);
            db.SaveChanges();

        }
        public void updateRange(List<T> t1)
        {

            db.UpdateRange(t1);
            db.SaveChanges();
        }

        public virtual List<T> list()
        {
            return db.Set<T>().ToList();
        }

        public T findById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public T findByGuid(Guid guid)
        {
            return db.Set<T>().Find(guid);
        }
    }
}
