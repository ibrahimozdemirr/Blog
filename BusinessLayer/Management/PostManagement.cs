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
    public class PostManagement : IGenericService<Posts>
    {
        EFPostsDAL eFPostsDAL;
        
        public PostManagement(EFPostsDAL eFPostsDAL)
        {
            this.eFPostsDAL = eFPostsDAL;
        }
        public void addService(Posts u)
        {
            eFPostsDAL.add(u);
        }

        public void addRangeService(List<Posts> u)
        {
            eFPostsDAL.addRange(u);
        }

        public void removeService(Posts u)
        {
            eFPostsDAL.remove(u);
        }
        public void removeRangeService(List<Posts> u)
        {
            eFPostsDAL.removeRange(u);
        }


        public void updateService(Posts u)
        {
            eFPostsDAL.update(u);
        }

        public void updateRangeService(List<Posts> u)
        {
            eFPostsDAL.updateRange(u);
        }

        public List<Posts> getService()
        {
            return eFPostsDAL.list();
        }

        public Posts findById(int id)
        {
            return eFPostsDAL.findById(id);
        }

        public Posts findByGuid(Guid guid)
        {
            return eFPostsDAL.findByGuid(guid);
        }
    }
}
