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
    public class UserManagment : IGenericService<Users>
    {
        EFUsersDAL eFUsersDAL;

        public UserManagment(EFUsersDAL eFUsersDAL)
        {
            this.eFUsersDAL = eFUsersDAL;
        }

        public void addService(Users u)
        {
            eFUsersDAL.add(u);
        }

        public void addRangeService(List<Users> u)
        {
            eFUsersDAL.addRange(u);
        }

        public void removeService(Users u)
        {
            eFUsersDAL.remove(u);
        }
        public void removeRangeService(List<Users> u)
        {
            eFUsersDAL.removeRange(u);
        }


        public void updateService(Users u)
        {
            eFUsersDAL.update(u);
        }

        public void updateRangeService(List<Users> u)
        {
            eFUsersDAL.updateRange(u);
        }

        public List<Users> getService()
        {
            return eFUsersDAL.list();
        }

        public Users findById(int id)
        {
            return eFUsersDAL.findById(id);
        }

        public Users findByGuid(Guid guid)
        {
            return eFUsersDAL.findByGuid(guid);
        }
    }
}
