using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using PairingTest.Web.App_Start;
using PairingTest.Web.Services;
using SimpleInjector;

namespace PairingTest.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private Container _container;

        protected void Application_Start()
        {
            _container = SimpleInjectorWebApiInitializer.Initialize();

            MapperConfig.Setup();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            _container.Dispose();
        }
    }
}