using System.Collections.Generic;
using System.IO;
using System.Net.Http.Formatting;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using WebApiApplication.Configure;
using WebApiApplication.Services;
using WebApiApplication.Services.Implementation;

namespace WebApiApplication
{
    public class WebApplication : System.Web.HttpApplication
    {
        private readonly Container _container = new Container();

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration;
            
            config.Formatters.Remove((MediaTypeFormatter) config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
                (JsonConverter) new StringEnumConverter());
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                (IContractResolver) new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
        }

        protected void RegisterDependencyInjection()
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            CommonLibrary.RegisterDependencyInjection(_container);
            _container.Register<IHomeControllerService, HomeControllerService>(Lifestyle.Singleton);
            // This is an extension method from the integration package.
            _container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            _container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(_container);
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