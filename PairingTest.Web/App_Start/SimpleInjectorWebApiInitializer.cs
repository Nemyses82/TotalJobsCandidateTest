using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using PairingTest.Web.Services;
using PairingTest.Web.Services.Contracts;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace PairingTest.Web
{
    [ExcludeFromCodeCoverage]
    public static class SimpleInjectorWebApiInitializer
    {
        public static Container Initialize()
        {
            var container = new Container();

            container.RegisterSingleton<ITypeMapper, TypeMapper>();
            container.RegisterSingleton<IQuestionnaireService, QuestionnaireService>();
            container.RegisterSingleton<IApiRequestService, ApiRequestService>();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            return container;
        }
    }
}