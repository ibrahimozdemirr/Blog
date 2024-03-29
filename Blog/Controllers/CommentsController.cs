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
    public class CommentsController : Controller
    {
        //private readonly BlogDBContext _context;
        CommentManagement cmm = new CommentManagement(new EFCommentsDAL());
        PostManagement pm = new PostManagement(new EFPostsDAL());
        UserManagment um = new UserManagment(new EFUsersDAL());
        //public CommentsController(BlogDBContext context)
        //{
        //    _context = context;
        //}

        // GET: Comments
        public async Task<IActionResult> Index()
        {
           
            return View(cmm.getService());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var comments = cmm.findByGuid(id);

            return View(comments);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            ViewData["postId"] = new SelectList(pm.getService(), "PostId", "PostDescription");
            ViewData["userId"] = new SelectList(um.getService(), "UserId", "UserFullName");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,CommentWritername,CommentDescription,CommentPhoto,CommentDate,CommentIsActive,userId,postId")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                comments.CommentId = Guid.NewGuid();
                cmm.addService(comments);
                return RedirectToAction(nameof(Index));
            }
            ViewData["postId"] = new SelectList(pm.getService(), "PostId", "PostDescription", comments.postId);
            ViewData["userId"] = new SelectList(um.getService(), "UserId", "UserFullName", comments.userId);
            return View(comments);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var comments = cmm.findByGuid(id);
            if (comments == null)
            {
                return NotFound();
            }
            ViewData["postId"] = new SelectList(pm.getService(), "PostId", "PostDescription", comments.postId);
            ViewData["userId"] = new SelectList(um.getService(), "UserId", "UserFullName", comments.userId);
            return View(comments);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CommentId,CommentWritername,CommentDescription,CommentPhoto,CommentDate,CommentIsActive,userId,postId")] Comments comments)
        {
            if (id != comments.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   cmm.updateService(comments);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentsExists(comments.CommentId))
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
            ViewData["postId"] = new SelectList(pm.getService(), "PostId", "PostDescription", comments.postId);
            ViewData["userId"] = new SelectList(um.getService(), "UserId", "UserFullName", comments.userId);
            return View(comments);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comments = cmm.findByGuid(id);
            if (comments == null)
            {
                return NotFound();
            }
            cmm.removeService(comments);
            return View(comments);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var comments = cmm.findByGuid(id);
            if (comments != null)
            {
                cmm.removeService(comments);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CommentsExists(Guid id)
        {
            return cmm.findByGuid(id).Equals(id);
        }
    }
}
