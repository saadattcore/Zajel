using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emaratech.Services.Systems.Api;
using Emaratech.Services.Systems.Model;
using System.Configuration;

namespace Emaratech.Services.Zajel.DataAccess
{
    public class SystemSettings
    {
        private Lazy<List<RestSystemConfigurationProperty>> SystemPropertiesLazy { get; }
        // private List<RestSystemConfigurationProperty> SystemProperties { get; }
        private ISystemApi SystemApi { get;}

        public SystemSettings(string systemId, ISystemApi systemApi)
        {
            SystemApi = systemApi;
            // SystemProperties = systemApi.GetAllProperties(systemId);     
            SystemPropertiesLazy = new Lazy<List<RestSystemConfigurationProperty>>(() => systemApi.GetAllProperties(systemId));
    }

        public string ZajelBranchId => SystemPropertiesLazy.Value.Single(x => x.PropName == "Zajel.BranchId").PropValue;
        public string ZajelClientId => SystemPropertiesLazy.Value.Single(x => x.PropName == "Zajel.ClientId").PropValue;
        public string ZajelUserId => ConfigurationManager.AppSettings["ZajelUserId"];

    }
}