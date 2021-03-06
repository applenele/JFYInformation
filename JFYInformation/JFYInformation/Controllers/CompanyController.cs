﻿using JFYInformation.Helpers;
using JFYInformation.Models;
using JFYInformation.Models.ViewModel;
using JFYInformation.Schmas;
using PagedList;
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
        public ActionResult Index(int? Statu, int? DealResult, string Key, DateTime? Begin, DateTime? End, string City, int page = 1)
        {
            var Cities = new List<City>();
            var query = db.Companies.AsEnumerable();
            List<vCompany> companies = new List<vCompany>();
            if (Begin.HasValue)
            {
                query = query.Where(c => c.Time >= Begin);
            }
            if (End.HasValue)
            {
                query = query.Where(c => c.Time <= End);
            }
            if (Statu.HasValue)
            {
                query = query.Where(c => c.StatuAsInt == Statu);
            }
            if (DealResult.HasValue)
            {
                query = query.Where(c => c.DealResultAsInt == DealResult);
            }
            if (!string.IsNullOrEmpty(City))
            {
                query = query.Where(c => c.Source.Contains(City) || c.Address.Contains(City));
            }
            if (!string.IsNullOrEmpty(Key))
            {
                query = query.Where(c => c.CompanyName.Contains(Key));
            }
            query = query.OrderByDescending(x => x.Time);
            ViewBag.CompanyCount = query.Count();
            int totalCount = 0;
            DoPage(ref query, page, 20, ref totalCount);
            foreach (var item in query)
            {
                companies.Add(new vCompany(item));
            }
            var citiesAsIPagedList = new StaticPagedList<vCompany>(companies, page, 20, totalCount);

            Cities = db.Cities.ToList();
            ViewBag.Cities = Cities;
            return View(citiesAsIPagedList);
        }

        public void DoPage(ref IEnumerable<Company> src, int Page, int PageSize, ref int totalCount)
        {
            totalCount = src.Count();
            src = src.Skip((Page - 1) * PageSize).Take(PageSize).ToList();
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

        #region 处理
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
                var record = new DealRecord();
                record = db.DealRecords.Where(r => r.CompanyID == id).FirstOrDefault();
                if (record == null)
                {
                    record = new DealRecord();
                    record.UID = CurrentUser.ID;
                    record.CompanyID = id;
                    record.Time = DateTime.Now;
                    record.DealResultAsInt = result;
                    db.DealRecords.Add(record);
                }
                else
                {
                    var _record = new DealRecord();
                    _record.UID = CurrentUser.ID;
                    _record.DealResultAsInt = result;
                    _record.CompanyID = id;
                    _record.Time = DateTime.Now;
                    _record.Hint = "修改";
                    db.DealRecords.Add(record);
                }
                db.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("处理出错！");
            }

        }

        #endregion

        [HttpGet]
        public ActionResult CompanyEdit(int id)
        {
            Company company = new Company();
            company = db.Companies.Find(id);
            return View(company);
        }

        /// <summary>
        /// 公司编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CompanyEdit(Company model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var company = db.Companies.Find(model.ID);
                    company.CompanyName = model.CompanyName;
                    company.Address = model.Address;
                    company.Contacts = model.Contacts;
                    company.Industry = model.Industry;
                    company.Scale = model.Scale;
                    company.URL = model.URL;
                    company.Phone = model.Phone;
                    company.Source = model.Source;
                    company.Description = model.Description;
                    company.Property = model.Property;
                    db.SaveChanges();
                    return Redirect("/Company/CompanyShow/" + model.ID);
                }
                catch
                {
                    ModelState.AddModelError("", "修改出错");
                }
            }
            else
            {
                ModelState.AddModelError("", "信息填写错误");
            }
            return View();
        }


        [HttpGet]
        public ActionResult AddCompany()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCompany(Company model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Time = DateTime.Now;
                    db.Companies.Add(model);
                    db.SaveChanges();
                    return Redirect("/Company/Index");
                }
                catch
                {
                    ModelState.AddModelError("", "添加出错！");
                }
            }
            else
            {
                ModelState.AddModelError("", "信息填写错误");
            }
            return View();
        }
    }
}