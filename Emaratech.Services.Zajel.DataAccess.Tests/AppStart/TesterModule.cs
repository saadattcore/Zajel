using Ninject.Modules;

namespace Emaratech.Services.Zajel.DataAccess.Tests.AppStart
{
    class TesterModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<TestInjectingLogger.LoggerInjectTarget>().To<TestInjectingLogger.LoggerInjectTarget>();
        }

    }
}