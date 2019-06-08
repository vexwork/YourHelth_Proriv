


using Common;
using NLog;
using WebApiApplication.Services.Logging;
using WebApiApplication.Services.Logging.Implementation;
using WebApiApplication.Services.Patients;
using WebApiApplication.Services.Patients.Implementation;
using WebApiApplication.Handlers;

[assembly: WebActivator.PostApplicationStartMethod(typeof(WebApiApplication.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]
namespace WebApiApplication.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using WebApiApplication.Services;
    using WebApiApplication.Services.Implementation;
  
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<ILoggingService, LoggingService>(Lifestyle.Singleton);
            CommonLibrary.RegisterDependencyInjection(container);
            container.Register<IHomeControllerService, HomeControllerService>(Lifestyle.Singleton);
            container.Register<IPatientsControllerService, PatientsControllerService>(Lifestyle.Singleton);
            container.Register<LogRequestAndResponseHandler, LogRequestAndResponseHandler>(Lifestyle.Singleton);
        }
    }
}