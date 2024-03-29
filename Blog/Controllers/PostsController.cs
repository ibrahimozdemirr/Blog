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
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    
    public class PostsController : Controller
    {
        //private readonly BlogDBContext _context;

        PostManagement pm = new PostManagement(new EFPostsDAL());
        UserManagment um = new UserManagment(new EFUsersDAL());

        //public PostsController(BlogDBContext context)
        //{
        //    _context = new BlogDBContext();
        //}

        public async Task<IActionResult> Index()
        {

            return View(pm.getService());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var posts = pm.findByGuid(id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        public IActionResult Create()
        {
            //var data = HttpContext.Session.GetString("userName");
            //ViewData["userId"] = new Guid();//"9245fe4a-d402-451c-b9ed-9c1a04247482";//new SelectList(_context.Users, "UserId", "UserFullName");
            ViewData["userId"] = new SelectList(um.getService(), "UserId", "UserFullName");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,PostName,PostDescription,PostDate,PostIsActive,userId,categoryId")] Posts posts)
        {
            if (ModelState.IsValid)
            {

                posts.PostId = Guid.NewGuid();
                pm.addService(posts);
                return RedirectToAction(nameof(Index));
            }
            ViewData["userId"] = new SelectList(um.getService(), "UserId", "UserFullName", posts.userId);
            return View(posts);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var posts =  pm.findByGuid(id);
            if (posts == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(um.getService(), "UserId", "UserFullName" );
            return View(posts);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("PostId,PostName,PostDescription,PostDate,PostIsActive,userId,categoryId")] Posts posts)
        {
            if (id != posts.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   pm.updateService(posts);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostsExists(posts.PostId))
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
            ViewData["userId"] = new SelectList(um.getService(), "UserId", "UserFullName", posts.userId);
            return View(posts);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = pm.findByGuid(id);
            if (posts == null)
            {
                return NotFound();
            }
            pm.removeService(posts);
            return View();
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var posts =  pm.findByGuid(id);
            if (posts != null)
            {
                pm.removeService(posts);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PostsExists(Guid id)
        {
            var posts = pm.findByGuid(id);
            return posts.PostId.Equals(id);
        }
    }

}