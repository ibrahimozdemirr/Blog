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
    public class CommentManagement : IGenericService<Comments>
    {
        EFCommentsDAL eFCommentsDAL;

        public CommentManagement(EFCommentsDAL eFCommentsDAL)
        {
            this.eFCommentsDAL = eFCommentsDAL;
        }

        public void addService(Comments u)
        {
            eFCommentsDAL.add(u);
        }

        public void addRangeService(List<Comments> u)
        {
            eFCommentsDAL.addRange(u);
        }

        public void removeService(Comments u)
        {
            eFCommentsDAL.remove(u);
        }
        public void removeRangeService(List<Comments> u)
        {
            eFCommentsDAL.removeRange(u);
        }


        public void updateService(Comments u)
        {
            eFCommentsDAL.update(u);
        }

        public void updateRangeService(List<Comments> u)
        {
            eFCommentsDAL.updateRange(u);
        }

        public List<Comments> getService()
        {
            return eFCommentsDAL.list();
        }

        public Comments findById(int id)
        {
           return eFCommentsDAL.findById(id);
        }

        public Comments findByGuid(Guid guid)
        {
            return eFCommentsDAL.findByGuid(guid);
        }
    }
}
