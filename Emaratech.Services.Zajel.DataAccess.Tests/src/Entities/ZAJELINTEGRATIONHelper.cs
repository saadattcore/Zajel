using System;
using System.Collections.Generic;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Send;
using Emaratech.Services.Zajel.Entities;

namespace Emaratech.Services.Zajel.DataAccess.Tests.Entities
{
    public static class ZAJELINTEGRATIONHelper
    {
        public static List<ZAJELINTEGRATION> CreateDifferentZajelIntegrationRecords(string systemId01, string systemId02)
        {
            var diffList = new List<ZAJELINTEGRATION>()
            {
                CreateZajelIntegrationRecord("Perra",  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera", systemId02, "38233", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38235", "8849815", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849815", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813132", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813131", "Popeyy", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marinn",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 33", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62322", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26226", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.St, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Expresss", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord(systemId01,  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df53",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitDouble,  "91227", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91228", "Ok",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "ER",
                    "Everything is fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is not fine", "Super!"),
                CreateZajelIntegrationRecord("Pera",  systemId01, "38232", "8849813", "3813131", "Popeye", "Dubai Marina",
                    "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52",
                    (int)ProductTypeOptions.EntryPermitSingle,  "91227", "Ok",
                    "Everything is fine", "False!")
            };
            return diffList;
        }

        public static ZAJELINTEGRATION CreateZajelIntegrationRecord(
            string id, string systemId, string applicationId, string contactNo, string landline, 
            string sponsorName, string area, string address, string pobox, string odrStatus, 
            int deliveryMode, string applicationType, string fileNo, int productType, string airwayBillId, 
            string responseStatus, string responseDescription, string responseResult)
        {
            return new ZAJELINTEGRATION()
            {
                ID = id,
                SYSTEM_KEY = systemId,
                APPLICATION_ID = applicationId,
                CONTACTNO = contactNo,
                LANDLINENO = landline,
                SPONSORNAME = sponsorName,
                AREA = area,
                ADDRESS = address,
                POBOX = pobox,
                ODRSTATUS = odrStatus,
                DELIVERYMODE = deliveryMode,
                APPLICATIONTYPE = applicationType,
                FILENO = fileNo,
                PRODUCTTYPE = productType,
                AIRWAYBILLID = airwayBillId,
                RESPONSECURRENTSTATUS = responseStatus,
                RESPONSEDESCRIPTION = responseDescription,
                RESPONSERESULT = responseResult
            };
        }
    }
}
