using Emaratech.DatabaseLayer;
using Emaratech.Services.Application.Api;
using Emaratech.Services.Systems.Api;
using Emaratech.Services.Zajel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;

namespace Emaratech.Services.Zajel.DataAccess.Tests.AppStart
{
    [TestClass]
    public class TestServiceNinjectModule
    {
        [TestMethod]
        public void TestCreateIDbContext()
        {
            var kernel = new StandardKernel(new INinjectModule[] {new ServiceNinjectModule()});
            var dbContext = kernel.Get<IDbContext>();

            Assert.IsInstanceOfType(dbContext, typeof(ZajelContextUpd));
            Assert.IsNotNull(dbContext);
        }

        [TestMethod]
        public void TestCreateIUnitOfWork()
        {
            var kernel = new StandardKernel(new INinjectModule[] {new ServiceNinjectModule()});
            var uow = kernel.Get<IUnitOfWork>();

            Assert.IsInstanceOfType(uow, typeof(UnitOfWork));
            Assert.IsNotNull(uow);
        }

        [TestMethod]
        public void TestSystemsApi()
        {
            var kernel = new StandardKernel(new INinjectModule[] {new ServiceNinjectModule()});
            var systemApi = kernel.Get<ISystemApi>();

            Assert.IsInstanceOfType(systemApi, typeof(SystemApi));
            Assert.IsNotNull(systemApi);
        }
        
        [TestMethod]
        public void TestSystemSettings()
        {
            var kernel = new StandardKernel(new INinjectModule[] {new ServiceNinjectModule(), new TestHelperNinjectModule()});
            var testInjectionTarget = kernel.Get<TestInjectionTarget>();
            
            // Act
            var systemSettings = testInjectionTarget.RemoteServicesProxyFactory.CreateSystemSettings("0E56E4FE722847BCBD4F2569E2C87E14");

            // Assert
            Assert.IsNotNull(systemSettings);
            Assert.IsInstanceOfType(systemSettings, typeof(SystemSettings));
        }

        [TestMethod]
        public void TestApplicationApi()
        {
            var kernel = new StandardKernel(new INinjectModule[] { new ServiceNinjectModule(), new TestHelperNinjectModule() });
            var testInjectionTarget = kernel.Get<TestInjectionTarget>();

            // Act
            var applicationApi = testInjectionTarget.RemoteServicesProxyFactory.CreateApplicationApi();

            // Assert
            Assert.IsNotNull(applicationApi);
            Assert.IsInstanceOfType(applicationApi, typeof(ApplicationApi));
        }

    }
}