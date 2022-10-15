using Emaratech.Services.WcfCommons.Dynamic;
using log4net;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Emaratech.Services.Zajel.DataAccess
{
    [NinjectConfigurationClass]
    public class UtilsNinjectModule : NinjectModule
    {
        [NinjectConfigurationMethod]
        public static void Init(NinjectModule module)
        {
            module.Bind<ILog>().ToMethod(context =>
            {
                ILog retValue = context.Request.ParentRequest != null ?
                    LogManager.GetLogger(context.Request.ParentRequest.Service) :
                    LogManager.GetLogger("DefaultLogger");
                return retValue;
            }).InRequestScope();
        }

        public override void Load()
        {
            Init(this); 
        }
    }
}