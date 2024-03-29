
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IGenericService<T> where T : class
    {
        void addService(T u);

        void addRangeService(List<T> t1);

        void removeService(T u);
        void removeRangeService(List<T> t1);

        void updateService(T u);
        void updateRangeService(List<T> t1);

        T findById(int id);
        T findByGuid(Guid guid);

        List<T> getService();
    }
}
