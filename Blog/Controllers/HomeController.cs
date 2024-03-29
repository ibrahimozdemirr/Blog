using Blog.Models;
using BusinessLayer.Management;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.Diagnostics;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entity;


namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UserManagment um = new UserManagment(new EFUsersDAL());
        PostManagement pm = new PostManagement(new EFPostsDAL());
        TagManagement tm = new TagManagement(new EFTagsDAL());
        CategoriesManagement cm = new CategoriesManagement(new EFCategoriesDAL());
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Pst5"] = pm.getService().OrderByDescending(o=>o.PostDate).Take(5);// ilk üç adet kayýt eklme tarihine göre
            ViewData["Tags"] = tm.getService().OrderByDescending( f => f.TagId);
            ViewData["Categories"] = cm.getService().OrderByDescending(z => z.CategoryId);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());

            //return RedirectToAction("Index","Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
