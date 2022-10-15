using System;
using System.Collections.Generic;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Send;

namespace Emaratech.Services.Zajel.Common.Tests
{
    public static class ApplicationInfoHelpers
    {
        public static List<ApplicationInfo> CreateDifferentApplicationInfoRecords(string systemId01, string systemId02)
        {
            var diffList = new List<ApplicationInfo>()
            {
                CreateApplicationInfo(systemId02, "Pera", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Perr", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849815", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813132", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813131", "Popeyy", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813131", "Popeye", "Dubai Marinn",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 33", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62322", "26225", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26226", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.St, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Expresss", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df53",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitDouble),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
                CreateApplicationInfo(systemId01, "Pera", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52",
                    ProductTypeOptions.EntryPermitSingle),
            };
            return diffList;
        }

        public static ApplicationInfo CreateApplicationInfo(
            string systemId, string applicationId, string contactNo, string landline, string sponsorName, string area,
            string address, string pobox, string odrStatus, DeliveryModeOptions deliveryMode, string applicationType,
            string fileNo, ProductTypeOptions productType)
        {
            return new ApplicationInfo()
            {
                SystemId = systemId,
                ApplicationId = applicationId,
                ContactNo = contactNo,
                Landline = landline,
                SponsorName = sponsorName,
                Area = area,
                Address = address,
                PoBox = pobox,
                OdrStatus = odrStatus,
                DeliveryMode = deliveryMode,
                ApplicationType = applicationType,
                FileNo = fileNo,
                ProductType = productType
            };
        }
    }
}
