using JFYInformation.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JFYInformation.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("/");
            }
            return View();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(vLogin model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Password = Helpers.Encryt.GetMD5(model.Password.Trim());
                    var user = db.Users.Where(u => u.Username == model.Username.Trim() && u.Password == model.Password).FirstOrDefault();
                    if (user == null)
                    {
                        ModelState.AddModelError("", "用户或密码不正确！");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "登陆失败，请重试！");
                }

            }
            else
            {
                ModelState.AddModelError("", "信息填写错误！");
            }
            return View();
        }
    }
}