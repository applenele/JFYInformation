using JFYInformation.Helpers;
using JFYInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace JFYInformation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            List<string> links = new List<string>();

            List<string> baseUrls = new List<string>();
            List<string> urls = new List<string>();
            List<string> keys = new List<string>();

            baseUrls.Add("http://bj.58.com/job/pn1/?PGTID=159266601188573828500733788&ClickID=1");
            baseUrls.Add("http://bj.58.com/job/pn2/?PGTID=159266601188573828500733788&ClickID=1");
            baseUrls.Add("http://bj.58.com/job/pn3/?PGTID=159266601188573828500733788&ClickID=1");
            baseUrls.Add("http://bj.58.com/job/pn4/?PGTID=159266601188573828500733788&ClickID=1");
            baseUrls.Add("http://bj.58.com/job/pn5/?PGTID=159266601188573828500733788&ClickID=1");
            baseUrls.Add("http://bj.58.com/job/pn6/?PGTID=159266601188573828500733788&ClickID=1");
            baseUrls.Add("http://bj.58.com/job/pn7/?PGTID=159266601188573828500733788&ClickID=1");
            baseUrls.Add("http://bj.58.com/job/pn8/?PGTID=159266601188573828500733788&ClickID=1");

            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                //URL = "http://bj.58.com/jiazhengbaojiexin/22353664668041x.shtml",//URL这里都是测试     必需项
                URL = "http://bj.58.com/job/pn2/?PGTID=159266601188573828500733788&ClickID=1",
                Method = "get",//URL     可选项 默认为Get
            };

            /*foreach (var baseUrl in baseUrls)
            {
                item.URL = baseUrl;
                //得到HTML代码
                HttpResult result = http.GetHtml(item);
                string res = StringHelper.GetMidTxt(result.Html, "<div id=\"maincon\" class=\"maincon\">", "<div class=\"seleAll\" tongji_id=\"ZP_job_list_div_atAll\">");
                urls = StringHelper.RegMatchUrl(res);
                links.AddRange(urls);
            }
            using (DB db = new DB())
            {
                foreach (var link in links)
                {
                    item.URL = link;
                    HttpResult result = http.GetHtml(item);
                    if (result.Html == "")
                    {
                        continue;
                    }
                    string regexStr = "<input id=\"pagenum\" value=\"(?<key>\\S*)\"[\\S\\s]*?>";
                    string regexCompany = "<a class=\"companyName\"[\\S\\s]*?>(?<company>\\S*)</a>";
                    Regex r = new Regex(regexStr, RegexOptions.None);
                    Regex rcompany = new Regex(regexCompany, RegexOptions.None);
                    Match mc = r.Match(result.Html);
                    Match mccompany = rcompany.Match(result.Html);
                    string v = mc.Groups["key"].Value;
                    string companyName = mccompany.Groups["company"].Value;
                    Company company = new Company();
                    company.Phone = "http://image.58.com/showphone.aspx?v=" + v;
                    company.Time = DateTime.Now;
                }
            }
            */


            item.URL = "http://bj.58.com/zpwuliucangchu/22871129161377x.shtml?psid=107549447188574280840697065&entinfo=22871129161377_0";
            HttpResult result = http.GetHtml(item);
            string regexStr = "<input id=\"pagenum\" value=\"(?<key>\\S*)\"[\\S\\s]*?>";
            string regexCompany = "<a class=\"companyName\"[\\S\\s]*?>(?<companyName>\\S*)</a>";
            Regex r = new Regex(regexStr, RegexOptions.None);
            Regex rcompany = new Regex(regexCompany, RegexOptions.None);
            Match mc = r.Match(result.Html);
            Match mccompany = rcompany.Match(result.Html);
            string v = mc.Groups["key"].Value;
            string companyName = mccompany.Groups["companyName"].Value;



           // ViewBag.Links = links;
            //ViewBag.Keys = keys;
            return View();
        }
    }
}