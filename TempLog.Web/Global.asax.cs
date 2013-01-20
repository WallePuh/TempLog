using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TempLog.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            SetupSerialization();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void SetupSerialization()
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //json.SerializerSettings.PreserveReferencesHandling =
            //    Newtonsoft.Json.PreserveReferencesHandling.All;

            var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            var dcs = new DataContractSerializer(typeof(Models.Measurement), null, int.MaxValue,
                false, /* preserveObjectReferences: */ true, null);
            xml.SetSerializer<Models.Measurement>(dcs);
        }
    }
}