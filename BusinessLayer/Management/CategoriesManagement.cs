using BusinessLayer.Services;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Management
{
    public class CategoriesManagement : IGenericService<Categories>
    {
        EFCategoriesDAL eFCategoriesDAL;

        public CategoriesManagement(EFCategoriesDAL eFCategoriesDAL)
        {
            this.eFCategoriesDAL = eFCategoriesDAL;
        }

        public void addService(Categories u)
        {
            eFCategoriesDAL.add(u);
        }

        public void addRangeService(List<Categories> u)
        {
            eFCategoriesDAL.addRange(u);
        }

        public void removeService(Categories u)
        {
            eFCategoriesDAL.remove(u);
        }
        public void removeRangeService(List<Categories> u)
        {
            eFCategoriesDAL.removeRange(u);
        }


        public void updateService(Categories u)
        {
            eFCategoriesDAL.update(u);
        }

        public void updateRangeService(List<Categories> u)
        {
            eFCategoriesDAL.updateRange(u);
        }

        public List<Categories> getService()
        {
            return eFCategoriesDAL.list();
        }

        public Categories findById(int id)
        {
            return eFCategoriesDAL.findById(id);
        }

        public Categories findByGuid(Guid guid)
        {
            return eFCategoriesDAL.findByGuid(guid);
        }
    }
}
