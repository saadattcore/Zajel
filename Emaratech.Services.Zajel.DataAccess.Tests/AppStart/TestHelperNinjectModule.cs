using Ninject.Modules;

namespace Emaratech.Services.Zajel.DataAccess.Tests.AppStart
{
    class TestHelperNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<TestInjectionTarget>().To<TestInjectionTarget>();
        }
    }
}