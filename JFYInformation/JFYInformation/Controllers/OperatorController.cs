using JFYInformation.Helpers;
using JFYInformation.Models;
using JFYInformation.Schmas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JFYInformation.Controllers
{
    public class OperatorController : BaseController
    {
        #region 管理员管理
        /// <summary>
        ///  管理员管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OperatorManage(string key, int p = 1)
        {
            var query = db.Users.OrderBy(u => u.ID).AsEnumerable();
            query = query.OrderByDescending(x => x.Time);
            ViewBag.PageInfo = PagerHelper.Do(ref query, 20, p);
            return View(query);
        }
        #endregion

        #region 增加管理员
        /// <summary>
        ///  增加管理员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddManager()
        {
            return View();
        }
        #endregion

        #region 增加管理员
        /// <summary>
        /// 增加管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AddManager(User model)
        {
            model.Password = Helpers.Encryt.GetMD5(model.Password);
            db.Users.Add(model);
            db.SaveChanges();
            return Redirect("/Admin/ManagerManage");
        }
        #endregion

        #region 管理员删除
        /// <summary>
        ///  删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateSID]
        public ActionResult ManagerDelete(int id)
        {
            User user = new User();
            user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return Content("ok");
        }
        #endregion

        #region 管理员展示
        /// <summary>
        ///  管理员展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ManagerShow(int id)
        {
            User user = new User();
            user = db.Users.Find(id);
            ViewBag.User = user;
            return View();
        }
        #endregion

        #region 管理员密码重置
        /// <summary>
        ///  管理员密码重置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateManagerPwd(int id)
        {
            User user = new User();
            user = db.Users.Find(id);
            ViewBag.User = user;
            return View();
        }
        #endregion

        #region 管理员密码重置
        /// <summary>
        ///  管理员密码重置
        /// </summary>
        /// <param name="password"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateSID]
        public ActionResult UpdateManagerPwd(string password, int uid)
        {
            User user = new Models.User();
            user = db.Users.Find(uid);
            user.Password = Helpers.Encryt.GetMD5(password);
            db.SaveChanges();
            return Redirect("/Admin/ManagerManage");
        }
        #endregion

        #region 角色重置

        /// <summary>
        ///  角色重置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RoleUpdate(int id)
        {
            User user = new User();
            user = db.Users.Find(id);
            ViewBag.User = user;
            return View();
        }
        #endregion

        #region 执行角色重置
        /// <summary>
        ///  执行角色重置
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateSID]
        public ActionResult RoleUpdate(Role role, int uid)
        {
            User user = new Models.User();
            user = db.Users.Find(uid);
            user.Role = role;
            db.SaveChanges();
            return Redirect("/Admin/ManagerManage");
        }
        #endregion

        #region 管理员消息
        /// <summary>
        ///  消息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminMessage(string msg)
        {
            ViewBag.Msg = msg;
            return View();
        }
        #endregion

    }
}