using Emaratech.Services.Application.Api;

namespace Emaratech.Services.Zajel.DataAccess
{
    public interface IRemoteServicesProxyFactory
    {
        SystemSettings CreateSystemSettings(string systemId);
        IApplicationApi CreateApplicationApi();
    }
}