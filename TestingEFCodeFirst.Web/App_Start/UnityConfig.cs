using Microsoft.Practices.Unity;
using System.Web.Http;
using TestingEFCodeFirst.EF;
using Unity.WebApi;


namespace TestingEFCodeFirst.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUnityOfWork<Customer>, UnitOfWork<Customer>>(new ContainerControlledLifetimeManager()   );

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}