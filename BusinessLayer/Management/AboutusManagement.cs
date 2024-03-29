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

    public class AboutusManagement : IGenericService<AboutUs>
    {
        EFAboutusDAL eFAboutusDAL;

        public AboutusManagement(EFAboutusDAL eFAboutusDAL)
        {
            this.eFAboutusDAL = eFAboutusDAL;
        }

        public void addService(AboutUs u)
        {
            eFAboutusDAL.add(u);
        }

        public void addRangeService(List<AboutUs> u)
        {
            eFAboutusDAL.addRange(u);
        }

        public void removeService(AboutUs u)
        {
            eFAboutusDAL.remove(u);
        }
        public void removeRangeService(List<AboutUs> u)
        {
            eFAboutusDAL.removeRange(u);
        }


        public void updateService(AboutUs u)
        {
            eFAboutusDAL.update(u);
        }

        public void updateRangeService(List<AboutUs> u)
        {
            eFAboutusDAL.updateRange(u);
        }

        public List<AboutUs> getService()
        {
            return eFAboutusDAL.list();
        }

        public AboutUs findById(int id)
        {
            return eFAboutusDAL.findById(id);
        }

        public AboutUs findByGuid(Guid guid)
        {
            return eFAboutusDAL.findByGuid(guid);
        }
    }
}
