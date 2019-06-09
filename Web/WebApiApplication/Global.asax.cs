using System.Collections.Generic;
using System.IO;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SimpleInjector;
using WebApiApplication.Configure;
using WebApiApplication.Filters;
using WebApiApplication.Handlers;

namespace WebApiApplication
{
    public class WebApplication : System.Web.HttpApplication
    {
        internal static Container WebApplicationContainer = new Container();

        internal readonly Container Container = WebApplicationContainer;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
                new StringEnumConverter());
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
           
            config.MessageHandlers.Add(new LogRequestAndResponseHandler());
            config.Filters.Add(new GlobalExceptionHandlerFilterAttribute());
        }


        public static IEnumerable<string> GetXmlDocs()
        {
            return new[]
            {
                Path.Combine(HttpRuntime.AppDomainAppPath, "bin", "Common.xml"),
                Path.Combine(HttpRuntime.AppDomainAppPath, "bin", "WebApiApplication.xml"),
            };
        }
    }
}