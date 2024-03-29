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

    public class TagManagement : IGenericService<Tags>
    {
        EFTagsDAL eFTagsDAL;

        public TagManagement(EFTagsDAL eFTagsDAL)
        {
            this.eFTagsDAL = eFTagsDAL;
        }

        public void addService(Tags u)
        {
            eFTagsDAL.add(u);
        }

        public void addRangeService(List<Tags> u)
        {
            eFTagsDAL.addRange(u);
        }

        public void removeService(Tags u)
        {
            eFTagsDAL.remove(u);
        }
        public void removeRangeService(List<Tags> u)
        {
            eFTagsDAL.removeRange(u);
        }


        public void updateService(Tags u)
        {
            eFTagsDAL.update(u);
        }

        public void updateRangeService(List<Tags> u)
        {
            eFTagsDAL.updateRange(u);
        }

        public List<Tags> getService()
        {
            return eFTagsDAL.list();
        }

        public Tags findById(int id)
        {
            return eFTagsDAL.findById(id);
        }

        public Tags findByGuid(Guid guid)
        {
            return eFTagsDAL.findByGuid(guid);
        }
    }
}
