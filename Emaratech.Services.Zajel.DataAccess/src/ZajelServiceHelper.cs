using Emaratech.Services.Common.Models;
using Emaratech.Services.Zajel.Contracts.Rest.Models;
using Emaratech.Services.Zajel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Emaratech.Services.Zajel.DataAccess.src
{
    public static class ZajelServiceHelper
    {
        public static IQueryable<ZAJELINTEGRATION> FilterStatus(IQueryable<ZAJELINTEGRATION> allApps)
        {
            var status = new List<string> { "Customer Engaged", "Pickup Done", "Under Process", "Delivered" };
            allApps = allApps.Where(x => status.Any(s => x.RESPONSECURRENTSTATUS.Contains(s)));
            return allApps;
        }

        public static IQueryable<ZAJELINTEGRATION> GetCurrentApplication(IQueryable<ZAJELINTEGRATION> allApps, PagingRequest<SearchModel> pagingRequest)
        {
            if (!string.IsNullOrEmpty(pagingRequest.Request.ApplicationNumber))
            {
                allApps = allApps.Where(x => x.APPLICATION_ID.Contains(pagingRequest.Request.ApplicationNumber));
            }

            if (!string.IsNullOrEmpty(pagingRequest.Request.AWBNumber))
            {
                allApps = allApps.Where(x => x.AIRWAYBILLID.Contains(pagingRequest.Request.AWBNumber));
            }
            if (pagingRequest.Request.FromDate != null)
            {
                allApps = allApps.Where(x => DbFunctions.TruncateTime(x.CREATED) >= DbFunctions.TruncateTime(pagingRequest.Request.FromDate));
            }
            if (pagingRequest.Request.ToDate != null)
            {
                allApps = allApps.Where(x => DbFunctions.TruncateTime(x.CREATED) <= DbFunctions.TruncateTime(pagingRequest.Request.ToDate));
            }
            if (!string.IsNullOrEmpty(pagingRequest.Request.DeliveryStatus))
            {
                allApps = allApps.Where(x => x.RESPONSECURRENTSTATUS == pagingRequest.Request.DeliveryStatus);
            }

            return allApps;
        }
    }
}