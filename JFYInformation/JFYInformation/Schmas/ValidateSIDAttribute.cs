using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JFYInformation.Schmas
{
    class ValidateSIDAttribute:BaseAuthAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.QueryString["sid"] != null
                    && httpContext.Session["sid"].ToString() == httpContext.Request.QueryString["sid"]
                    || httpContext.Request.Form["sid"] != null
                    && httpContext.Session["sid"].ToString() == httpContext.Request.Form["sid"].ToString())
                return true;
            else
                return false;
        }
    }
}
