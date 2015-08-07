using JFYInformation.Helpers;
using JFYInformation.Models;
using JFYInformation.Models.ViewModel;
using JFYInformation.Schmas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JFYInformation.Controllers
{
    [Authorize]
    public class OperatorController : BaseController
    {
        #region 管理员管理
        /// <summary>
        ///  管理员管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OperatorManage(string key, DateTime? Begin, DateTime? End, int p = 1)
        {
           
            var query = db.Users.OrderBy(u => u.ID).AsEnumerable();
            if (Begin.HasValue)
            {
                query = query.Where(c => c.Time >= Begin);
            }
            if (End.HasValue)
            {
                query = query.Where(c => c.Time <= End);
            }
            if (!string.IsNullOrEmpty(key))
            {
                query = query.Where(c => c.Username.Contains(key) || c.RealName.Contains(key));
            }
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
        public ActionResult AddOperator()
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOperator(vRegister model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new User();
                    user.Username = model.Username;
                    user.Password = Helpers.Encryt.GetMD5(model.Password);
                    user.Role = model.Role;
                    user.Time = DateTime.Now;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Redirect("/Operator/OperatorManage");
                }
                catch
                {
                    ModelState.AddModelError("", "增加操作员出错！");
                }
            }
            else
            {
                ModelState.AddModelError("", "信息填写错误！");
            }
            return View();
        }
        #endregion

        #region 操作员删除
        /// <summary>
        ///  操作员删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateSID]
        public ActionResult OperatorDelete(int id)
        {
            User user = new User();
            user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return Content("ok");
        }
        #endregion

        #region 操作员展示
        /// <summary>
        ///  操作员展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult OperatorShow(int id)
        {
            User user = new User();
            user = db.Users.Find(id);
            return View(new vUser(user));
        }
        #endregion

        #region 操作员密码重置
        /// <summary>
        ///  操作员密码重置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateOperatorPwd(int id)
        {
            User user = new User();
            user = db.Users.Find(id);
            return View(user);
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
        [ValidateAntiForgeryToken]
        public ActionResult UpdateOperatorPwd(string password, int id)
        {
            User user = new Models.User();
            user = db.Users.Find(id);
            user.Password = Helpers.Encryt.GetMD5(password);
            db.SaveChanges();
            return Redirect("/Operator/OperatorManage");
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
            return View(user);
        }
        #endregion

        #region 执行角色重置
        /// <summary>
        ///  执行角色重置
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleUpdate(Role role, int id)
        {
            User user = new Models.User();
            user = db.Users.Find(id);
            user.Role = role;
            db.SaveChanges();
            return Redirect("/Operator/OperatorManage");
        }
        #endregion


    }
}