using Microsoft.Practices.Unity;
using System.Web.Http;
using TestingEFCodeFirst.Data;
using TestingEFCodeFirst.EF;
using TestingEFCodeFirst.EF.Dao;
using TestingEFCodeFirst.Services;
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


            #region Daos

            container.RegisterType<ICustomerDao, CustomerDao>(new ContainerControlledLifetimeManager());

            #endregion

            #region Services

            container.RegisterType<ICustomerService, CustomerService>(new ContainerControlledLifetimeManager());

            #endregion

            container.RegisterInstance(typeof(CustomerDbContext), new CustomerDbContext(),
                new ContainerControlledLifetimeManager());

            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}