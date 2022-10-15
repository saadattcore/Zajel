namespace Emaratech.Services.Zajel.DataAccess.Tests.AppStart
{
    class TestInjectionTarget
    {
        public IRemoteServicesProxyFactory RemoteServicesProxyFactory { get; set; }

        public TestInjectionTarget(IRemoteServicesProxyFactory remoteServicesProxyFactory)
        {
            RemoteServicesProxyFactory = remoteServicesProxyFactory;
        }
    }
}