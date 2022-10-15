using System;
using System.Configuration;
using AutoMapper;
using Emaratech.DatabaseLayer;
using Emaratech.Services.Ado;
using Emaratech.Services.Ado.Oracle;
using Emaratech.Services.Application.Api;
using Emaratech.Services.Common;
using Emaratech.Services.Systems.Api;
using Emaratech.Services.WcfCommons.Dynamic;
using log4net.Config;
using Ninject.Modules;
using Ninject.Web.Common;
using Emaratech.Services.Zajel.Entities;
using Ninject.Activation;
using Ninject.Extensions.Factory;

namespace Emaratech.Services.Zajel.DataAccess
{
    [NinjectConfigurationClass]
    public class ServiceNinjectModule : NinjectModule
    {
        [NinjectConfigurationMethod]
        public static void Init(NinjectModule module)
        {
            module.Bind<IAccessContext>().To<AnonymousAccessContext>().InSingletonScope();

            // Old version
            // this.Bind<IDbContext>().ToMethod(context => ZajelDbProvidersFactory.GetDbContext()).InRequestScope();
            // this.Bind<IUnitOfWork>().ToMethod(context => ZajelDbProvidersFactory.GetUnitOfWork()).InRequestScope();
            // Probably such binding can be moved to an entity assembly (or some different assembly).

            module.Bind<IDbContext>().To<ZajelContextUpd>().InRequestScope();
            module.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            module.Bind<IDateTimeProvider>().To<DefaultDateTimeProvider>().InSingletonScope();
            module.Bind<ISystemApi>().ToMethod(x => new SystemApi(ConfigurationManager.AppSettings["SystemApi"])).InRequestScope();
            module.Bind<IApplicationApi>().ToMethod(x => new ApplicationApi(ConfigurationManager.AppSettings["ApplicationApi"])).InRequestScope();
            module.Bind<IRemoteServicesProxyFactory>().ToFactory();

            BindServices(module);

        }

        private static void BindServices(NinjectModule module)
        {
            var setting = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MockZajelServiceClient"]);

            switch (setting)
            {
                case 0:
                    module.Bind<ZajelServiceExternal.IZ360Service>().
                   To<ZajelServiceExternal.Z360ServiceClient>()
                   .InRequestScope()
                   .WithConstructorArgument("endpointConfigurationName", "BasicHttpBinding_IZ360Service");
                    break;

                case 1:
                    module.Bind<ZajelServiceExternal.IZ360Service>()
                   .To<Emaratech.Services.Zajel.DataAccess.Fakes.FakeZajelServiceClient>()
                   .InRequestScope();
                    break;

                default:
                    throw new Exception("Plesae specify valid MockZajelServiceClient value in  app setting  config . Possible values are 0 or 1");
            }
        }


        public override void Load()
        {
            XmlConfigurator.Configure();

            var mapperConfig = new MapperConfiguration(_ => { });
            mapperConfig.Configure();
            var mapper = mapperConfig.CreateMapper();

            this.Bind<IMapper>().ToConstant(mapper).InSingletonScope();

            Init(this);
        }
    }
}