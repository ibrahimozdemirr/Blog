using BusinessLayer.Management;
using BusinessLayer.Validations;
using Castle.Core.Resource;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Blog.Controllers
{
    public class LoginController : Controller
    {
        LoginValidations lv=new LoginValidations();
        UserManagment um =new UserManagment(new DataAccessLayer.EntityFramework.EFUsersDAL());
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(Users users)
        {
            //ValidationResult results = lv.Validate(users);

            //if (!results.IsValid)
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }
            //}

            //panele yönlrnrieme 

            // veritabanı doğrulama yapılmalı var mı yok mu ?
            var checkUser=um.getService().Where(i=>i.UserName==users.UserName).FirstOrDefault();
            return View();
        }
        public IActionResult Singup() 
        { 
            return View(); 
        }

        public IActionResult ForgotPassword() 
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
