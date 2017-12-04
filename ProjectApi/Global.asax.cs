using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ProjectApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
 
    protected void Application_Start()
    {
        GlobalConfiguration.Configure(WebApiConfig.Register);
    }

    public void Application_BeginRequest(object sender, EventArgs e)
    {
        AddCorsForAngular4(sender);
    }

    private void AddCorsForAngular4(object sender)
    {
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", ConfigurationManager.AppSettings["allowed-cors-origins"]);
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers",
            "Origin, X-Requested-With, Content-Type, Accept, X-Token");
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true");

        if (Request.HttpMethod == "OPTIONS")
        {
            HttpContext.Current.Response.StatusCode = 200;
            var httpApplication = sender as HttpApplication;
            httpApplication.CompleteRequest();
        }
    }
    }
}
