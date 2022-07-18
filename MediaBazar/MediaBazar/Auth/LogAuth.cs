using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaBazar.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class LogAuth : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var value = httpContext.Session["logged_user"];
            //var authenticated = base.AuthorizeCore(httpContext);
            if (value != null)
            {
                if (httpContext.Session["role"].ToString().Equals("Consumer"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}