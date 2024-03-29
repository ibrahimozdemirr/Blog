using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity;
using BusinessLayer.Management;
using DataAccessLayer.EntityFramework;

namespace Blog.Controllers
{
    public class UsersController : Controller
    {
        //private readonly BlogDBContext _context;
        UserManagment um = new UserManagment(new EFUsersDAL());

        //public UsersController(BlogDBContext context)
        //{
        //    _context = context;
        //}

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(um.getService());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var users = um.findByGuid(id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserFullName,UserName,UserPassword,UserEmail,UserAbout,UserPicture,UserIsActive")] Users users)
        {
            if (ModelState.IsValid)
            {
                users.UserId = Guid.NewGuid();
                um.addService(users);
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var users = um.findByGuid(id);
            if (users == null)
            {
                return NotFound();
            }
            um.updateService(users);
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UserId,UserFullName,UserName,UserPassword,UserEmail,UserAbout,UserPicture,UserIsActive")] Users users)
        {
            if (id != users.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    um.updateService(users);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UserId))
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
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = um.findByGuid(id);
            if (users == null)
            {
                return NotFound();
            }
            um.removeService(users);
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var users = um.findByGuid(id);
            if (users != null)
            {
                um.removeService(users);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(Guid id)
        {
            return um.findByGuid(id).Equals(id);
        }
    }
}
