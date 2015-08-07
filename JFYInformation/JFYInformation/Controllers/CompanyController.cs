using JFYInformation.Helpers;
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
    }
}