using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
