[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Flash.Club13.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Flash.Club13.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Flash.Club13.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using AutoMapper;
    using System.Data.Entity;
    using Flash.Club13.Data;
    using Flash.Club13.Data.Repository;
    using Flash.Club13.Data.UnitOfWork;
    using Flash.Club13.Interfaces.Services;
    using Flash.Club13.Services;
    using Flash.Club13.Auth.Service.Interfaces;
    using Flash.Club13.Auth.Service;
    using Microsoft.AspNet.Identity.Owin;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(DbContext), typeof(MainDbContext)).To<MainDbContext>().InRequestScope();

            kernel.Bind<ISignInService>().ToMethod(_ => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>());
            kernel.Bind<IUserService>().ToMethod(_ => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());

            kernel.Bind(typeof(IEfRepostory<>)).To(typeof(EfRepostory<>)).InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            kernel.Bind<ITestService>().To<TestService>().InRequestScope();
            kernel.Bind<IExerciseService>().To<ExerciseService>().InRequestScope();

            kernel.Bind<IMapper>().ToMethod(x => Mapper.Instance).InSingletonScope();
        }        
    }
}
