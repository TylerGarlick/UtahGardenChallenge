using System.Data.Entity;
using UtahsOwnGardenChallenge.Data;
using UtahsOwnGardenChallenge.Repositories;
using UtahsOwnGardenChallenge.Repositories.EntityFramework;
using UtahsOwnGardenChallenge.Services;

[assembly: WebActivator.PreApplicationStartMethod(typeof(UtahsOwnGardenChallenge.Mvc.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(UtahsOwnGardenChallenge.Mvc.App_Start.NinjectWebCommon), "Stop")]

namespace UtahsOwnGardenChallenge.Mvc.App_Start
{
	using System;
	using System.Web;

	using Microsoft.Web.Infrastructure.DynamicModuleHelper;

	using Ninject;
	using Ninject.Web.Common;

	public static class NinjectWebCommon
	{
		private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

		public static IKernel Kernel { get; private set; }

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			Bootstrapper.Initialize(CreateKernel);
		}

		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			Bootstrapper.ShutDown();
		}

		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
			kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

			RegisterServices(kernel);
			Kernel = kernel;
			return kernel;
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			kernel.Bind<DbContext>().To<DatabaseDbContext>().InRequestScope();

			kernel.Bind<ICityRepository>().To<CityRepository>().InRequestScope();
			kernel.Bind<ICountyRepository>().To<CountyRepository>().InRequestScope();
			kernel.Bind<IGardenReasonRepository>().To<GardenReasonRespository>().InRequestScope();
			kernel.Bind<IGardenRepository>().To<GardenRepository>().InRequestScope();
			kernel.Bind<IGardenSizeRepository>().To<GardenSizeRepository>().InRequestScope();
			kernel.Bind<IGardenTypeRepository>().To<GardenTypeRepository>().InRequestScope();
			kernel.Bind<IPlantTypeRepository>().To<PlantTypeRepository>().InRequestScope();

			kernel.Bind<IGardenService>().To<GardenService>().InRequestScope();
			kernel.Bind<ICountyService>().To<CountyService>().InRequestScope();
			kernel.Bind<IGardenReasonService>().To<GardenReasonService>().InRequestScope();
			kernel.Bind<IGardenSizeService>().To<GardenSizeService>().InRequestScope();
			kernel.Bind<IGardenTypeService>().To<GardenTypeService>().InRequestScope();
			kernel.Bind<IPlantTypeService>().To<PlantTypeService>().InRequestScope();
		}
	}
}
