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
    public class EFCategoriesDAL : GenericRepoDAL<Categories>,IGenericDAL<Categories>
    {
    }
}
