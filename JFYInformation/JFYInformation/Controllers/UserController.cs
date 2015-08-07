using JFYInformation.Models;
using JFYInformation.Models.ViewModel;
using JFYInformation.Schmas;
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

        #region 注销
        /// <summary>
        ///  注销 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ValidateSID]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
        #endregion


        /// <summary>
        /// 用户展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Show(int id)
        {
            var user = db.Users.Find(id);
            return View(new vUser(user));
        }


        [Authorize]
        public ActionResult ShowPicture(int id)
        {
            User user = new User();
            user = db.Users.Find(id);
            return File(user.Picture, "image/jpg");
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = db.Users.Find(id);
            return View(user);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(vUser model)
        {
            var user = db.Users.Find(model.ID);
            if (ModelState.IsValid)
            {
                user.Phone = model.Phone;
                user.Address = model.Address;
                user.RealName = model.RealName;
                db.SaveChanges();
                return Redirect("/User/Show/"+model.ID);
            }
            else
            {
                ModelState.AddModelError("","信息填写错误！");
            }
            return View(user);
        }
    }
}