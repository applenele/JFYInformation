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
    public class CompanyController : BaseController
    {
        // GET: Company
        public ActionResult Index(int p = 0)
        {
            var query = db.Companies.AsEnumerable();

            query = query.OrderByDescending(x => x.Time);
            ViewBag.PageInfo = PagerHelper.Do(ref query, 20, p);
            return View(query);
        }


        #region 公司删除
        /// <summary>
        /// 公司删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateSID]
        public ActionResult CompanyDelete(int id)
        {
            try
            {
                var company = db.Companies.Find(id);
                db.Companies.Remove(company);
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
        /// 公司展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CompanyShow(int id)
        {
            var company = db.Companies.Find(id);
            return View(new vCompany(company));
        }

        [HttpGet]
        public ActionResult CompanyEdit(int id)
        {
            Company company = new Company();
            return View(company);
        }


    }
}