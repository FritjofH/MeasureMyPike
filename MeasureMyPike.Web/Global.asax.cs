using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MeasureMyPike
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var config = GlobalConfiguration.Configuration;
            config.Formatters.Remove(config.Formatters.JsonFormatter);

            var serializer = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver
                {
                    IgnoreSerializableAttribute = true,
                    IgnoreSerializableInterface = true
                }
            };

            // Remove the JSON formatter
            config.Formatters.Remove(config.Formatters.JsonFormatter);
            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Add JSON media type formatter
            var formatter = new JsonMediaTypeFormatter { Indent = true, SerializerSettings = serializer };
            config.Formatters.Insert(0, formatter);
        }
    }
}
