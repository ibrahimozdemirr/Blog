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

namespace Blog.Controllers
{
    public class TagsController : Controller
    {
        //private readonly BlogDBContext _context;
        TagManagement tm = new TagManagement(new EFTagsDAL());
        PostManagement pm = new PostManagement(new EFPostsDAL());
        //public TagsController(BlogDBContext context)
        //{
        //    _context = context;
        //}

        // GET: Tags
        public async Task<IActionResult> Index()
        {
            return View(tm.getService());
        }

        // GET: Tags/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var tags = tm.findByGuid(id);
            return View(tags);
        }

        // GET: Tags/Create
        public IActionResult Create()
        {
            ViewData["postId"] = new SelectList(pm.getService(), "postId");
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TagId,TagName")] Tags tags)
        {
            if (ModelState.IsValid)
            {
                tags.TagId = Guid.NewGuid();
                tm.addService(tags);
                return RedirectToAction(nameof(Index));
            }
            return View(tags);
        }

        // GET: Tags/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var tags = tm.findByGuid(id);
            if (tags == null)
            {
                return NotFound();
            }
            ViewData["postId"] = new SelectList(pm.getService(), "postId");
            return View(tags);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TagId,TagName")] Tags tags)
        {
            if (id != tags.TagId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tm.updateService(tags);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagsExists(tags.TagId))
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
            return View(tags);
        }

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tags = tm.findByGuid(id);
            if (tags == null)
            {
                return NotFound();
            }
            tm.removeService(tags);
            return View(tags);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tags = tm.findByGuid(id);
            if (tags != null)
            {
                tm.removeService(tags);
            }

            
            return RedirectToAction(nameof(Index));
        }

        private bool TagsExists(Guid id)
        {
            return tm.findByGuid(id).Equals(id);
        }
    }
}
