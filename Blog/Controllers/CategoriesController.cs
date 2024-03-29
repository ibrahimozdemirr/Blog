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
using DataAccessLayer.EntityFramework;
using System.Collections.Immutable;


namespace Blog.Controllers
{
    public class CategoriesController : Controller
    {
        //private readonly BlogDBContext _context;

        CategoriesManagement cm = new CategoriesManagement(new EFCategoriesDAL());
        PostManagement pm = new PostManagement(new EFPostsDAL());
        //public CategoriesController(BlogDBContext context)
        //{
        //    _context = context;
        //}

        // GET: Categories
        public async Task<IActionResult> Index()
        {

            return View(cm.getService());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var categories = cm.findByGuid(id);
            return View(categories);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            ViewData["postId"] = new SelectList(pm.getService(), "postId");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                categories.CategoryId = Guid.NewGuid();
                cm.addService(categories);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["postId"] = new SelectList(cm.getService(), "PostId", "PostDescription", categories.postId);
            return View(categories);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var categories = cm.findByGuid(id);
            return View(categories);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CategoryId,CategoryName")] Categories categories)
        {
            if (id != categories.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cm.updateService(categories);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesExists(categories.CategoryId))
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
            return View(categories);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var categories = cm.findByGuid(id);

            if (categories == null)
            {
                return NotFound();
            }
            cm.removeService(categories);
            return View(categories);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var categories = cm.findByGuid(id);
            if (categories != null)
            {
                cm.removeService(categories);
            }


            return RedirectToAction(nameof(Index));
        }

        private bool CategoriesExists(Guid id)
        {
            return cm.findByGuid(id).Equals(id);
        }
    }
}
