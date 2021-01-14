using System.Web.Http;
using Unity;
using Unity.WebApi;
using WebApiAssignment.BAL;
using WebApiAssignment.BAL.Interface;
using WebApiAssignment.BAL.Helper;

namespace Web_Api_Final_Assignment
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();
			container.RegisterType<IHotelManager, HotelManager>();
			container.AddNewExtension<UnityRepositoryHelper>();
			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
		}
	}
}