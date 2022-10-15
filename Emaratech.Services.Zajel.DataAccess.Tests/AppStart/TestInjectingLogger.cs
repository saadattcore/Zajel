using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;

namespace Emaratech.Services.Zajel.DataAccess.Tests.AppStart
{
    [TestClass]
    public class TestInjectingLogger
    {
        [TestMethod]
        public void TestInjectingILog()
        {
            var kernel = new StandardKernel(new INinjectModule[] {new UtilsNinjectModule(), new TesterModule()});
            var injectTarget = kernel.Get<LoggerInjectTarget>();

            Assert.IsInstanceOfType(injectTarget, typeof(LoggerInjectTarget));
            Assert.IsNotNull(injectTarget);
            Assert.IsInstanceOfType(injectTarget.Logger, typeof(ILog));
            Assert.AreEqual(injectTarget.Logger.Logger.Name, typeof(LoggerInjectTarget).FullName);

        }
        public class LoggerInjectTarget
        {
            public ILog Logger { get; }
            public LoggerInjectTarget(ILog argLogger)
            {
                Logger = argLogger;
            }
        }

    }
}