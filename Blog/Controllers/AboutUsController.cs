using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using EntityLayer.Entity;
using BusinessLayer.Management;
using BusinessLayer.Services;
using DataAccessLayer.EntityFramework;
using NuGet.Protocol;
using Microsoft.Extensions.Hosting;

namespace Blog.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly BlogDBContext _context;

        AboutusManagement am = new AboutusManagement(new EFAboutusDAL());

        public AboutUsController(BlogDBContext context)
        {
            _context = context;
        }

        // GET: AboutUs
        public async Task<IActionResult> Index()
        {
            return View(am.getService());
        }

        // GET: AboutUs/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutus = am.findByGuid(id);
            if (aboutus == null)
            {
                return NotFound();
            }
            return View(aboutus);
        }

        // GET: AboutUs/Create
        public IActionResult Create()
        {
            ViewData["AboutId"] = new SelectList(am.getService(), "AboutId");
            return View();
        }

        // POST: AboutUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AboutId,AboutContent,AboutDate")] AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                aboutUs.AboutId = Guid.NewGuid();
                am.addService(aboutUs);
                return RedirectToAction(nameof(Index));
            }
            return View(aboutUs);
        }

        // GET: AboutUs/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var aboutUs = am.findByGuid(id);
            if (aboutUs == null)
            {
                return NotFound();
            }
            return View(aboutUs);
        }

        // POST: AboutUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AboutId,AboutContent,AboutDate")] AboutUs aboutUs)
        {
            if (id != aboutUs.AboutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    am.updateService(aboutUs);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutUsExists(aboutUs.AboutId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aboutUs);
        }

        // GET: AboutUs/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var aboutUs = am.findByGuid(id);
            if (aboutUs == null)
            {
                return NotFound();
            }
            am.removeService(aboutUs);

            return View(aboutUs);
        }

        // POST: AboutUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var aboutUs = am.findByGuid(id);
            if (aboutUs != null)
            {
                am.removeService(aboutUs);
            }

           
            return RedirectToAction(nameof(Index));
        }

        private bool AboutUsExists(Guid id)
        {
            return am.findByGuid(id).Equals(id);
        }
    }
}
