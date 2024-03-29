using DataAccessLayer.Context;
using DataAccessLayer.Interface;
using DataAccessLayer.Repostory;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFUsersDAL :GenericRepoDAL<Users>, IGenericDAL<Users>// UserRepoDAL, IUserDAL<Users>
    {
        BlogDBContext db = new BlogDBContext();
        public Users getAhmet (string s){

             
            return (Users)db.Users.Where(i=>i.UserName.StartsWith(s));
        }


    }
}
