using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IGenericDAL<T> where T : class
    {
        void add(T t);
        void remove(T t);
        void addRange(List<T> t1);
        void removeRange(List<T> t1);
        void update(T t);
        void updateRange(List<T> t);
        List<T> list();
        T findById(int id);
        T findByGuid(Guid guid);
    }
}
