using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Emaratech.Services.HealthCheck.EF;
using Emaratech.Services.WcfCommons.Dynamic;
using Emaratech.Services.WcfCommons.HealthCheck.Rest;
using Emaratech.Services.WcfCommons.Rest.Modules;
using Emaratech.Services.Zajel.Contracts.DataAccess;
using Emaratech.Services.Zajel.DataAccess;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Emaratech.Services.Zajel
{
    public class Global : NinjectHttpApplication
    {
        /// <summary>
        /// Creates the kernel that will manage application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        protected override IKernel CreateKernel()
        {
            var hostingModel =
                (DynamicHostingModel)
                    Enum.Parse(typeof(DynamicHostingModel),
                        ConfigurationManager.AppSettings["DataAccessHostingModel"] ??
                        DynamicHostingModel.InProcess.ToString());
            var modules = new List<INinjectModule>()
            {
                new ServiceNinjectModule(),
                new LoggingInitializationNinjectModule(),
                new SwaggerInitializationNinjectModule()
            };
            if (hostingModel == DynamicHostingModel.InProcess)
            {
                modules.Add(new AutoMapperInitializationNinjectModule());
                modules.Add(
                    new InProcessWcfClientInitializationNinjectModule<IZajelDataAccessService, ZajelDataAccessService>());
                modules.Add(new ExternalModuleInitializationNinjectModule());
                modules.Add(new InProcessHealthCheckInitializationModule<EFHealthcheckImpl>());
            }
            else
            {
                modules.Add(new AutoMapperInitializationNinjectModule(Assembly.GetExecutingAssembly()));
                modules.Add(
                    new RemoteWcfClientInitializationNinjectModule<IZajelDataAccessService>(
                        "BasicHttpBinding_IZajelDataAccessService"));
                modules.Add(new ServiceHealthCheckInitializationModule("BasicHttpBinding_IDataAccessHealthCheck"));
            }
            return new StandardKernel(modules.ToArray());
        }
    }
}