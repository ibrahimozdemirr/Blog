using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;

namespace Blog.Controllers
{
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            //HttpContext.Session.SetString("userName", "İbrahim");
            ////var data=HttpContext.Session.GetString("userName");
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
    }
}
