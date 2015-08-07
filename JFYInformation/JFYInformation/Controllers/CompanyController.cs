﻿using JFYInformation.Helpers;
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
        public ActionResult Index(int? Statu,int p = 0)
        {
            var query = db.Companies.AsEnumerable();
            List<vCompany> companies = new List<vCompany>();
            if (Statu.HasValue)
            {
                query = query.Where(c => c.StatuAsInt == Statu);
            }
            query = query.OrderByDescending(x => x.Time);
            ViewBag.PageInfo = PagerHelper.Do(ref query, 20, p);
            foreach (var item in query)
            {
                companies.Add(new vCompany(item));
            }
            return View(companies);
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

        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public ActionResult CompanyDeal(int id, int result)
        {
            try
            {
                var company = db.Companies.Find(id);
                company.StatuAsInt = 2;
                company.DealResultAsInt = result;
                db.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("处理出错！");
            }

        }

        [HttpGet]
        public ActionResult CompanyEdit(int id)
        {
            Company company = new Company();

            return View(company);
        }




    }
}