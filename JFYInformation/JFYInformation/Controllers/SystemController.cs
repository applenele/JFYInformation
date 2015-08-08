using JFYInformation.Helpers;
using JFYInformation.Models;
using JFYInformation.Schmas;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JFYInformation.Controllers
{
    public class SystemController : BaseController
    {
        // GET: System
        public ActionResult Index()
        {
            return View();
        }

        #region 城市管理
        /// <summary>
        /// 城市管理
        /// </summary>
        /// <param name="key"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public ActionResult CityManage(string key, int p = 0)
        {
            var query = db.Cities.AsEnumerable();
            if (!string.IsNullOrEmpty(key))
            {
                query = query.Where(c => c.CityName.Contains(key) || c.Province.Contains(key));
            }
            query = query.OrderByDescending(x => x.Time);
            ViewBag.CityCount = query.Count();
            ViewBag.PageInfo = PagerHelper.Do(ref query, 20, p);
            return View(query);
        }


        /// <summary>
        /// 增加城市
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddCity()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCity(City model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Time = DateTime.Now;
                    db.Cities.Add(model);
                    db.SaveChanges();
                    return Redirect("/System/CityManage");
                }
                catch
                {
                    ModelState.AddModelError("", "增加城市出现错误！");
                }
            }
            else
            {
                ModelState.AddModelError("", "信息填写错误");
            }
            return View();
        }

        [HttpPost]
        [ValidateSID]
        public ActionResult CityDelete(int id)
        {
            try
            {
                var city = db.Cities.Find(id);
                db.Cities.Remove(city);
                db.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }
        #endregion

        /// <summary>
        ///   处理记录
        /// </summary>
        /// <param name="DealResult"></param>
        /// <param name="Key"></param>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult DealResult(int? DealResult, string Key, DateTime? Begin, DateTime? End, int page = 1)
        {
            var query = db.DealRecords.AsEnumerable();
            if (DealResult.HasValue)
            {
                query = query.Where(r => r.DealResultAsInt == DealResult);
            }
            if (Begin.HasValue)
            {
                query = query.Where(r => r.Time >= Begin);
            }
            if (End.HasValue)
            {
                query = query.Where(r => r.Time <= End);
            }
            if (!string.IsNullOrEmpty(Key))
            {
                query = query.Where(r => r.User.Username.Contains(Key) || r.Company.CompanyName.Contains(Key));
            }
            ViewBag.RecordCount = query.Count();
            var records = query.OrderByDescending(r => r.Time).ToPagedList(page, 20);
            return View(records);
        }
    }
}