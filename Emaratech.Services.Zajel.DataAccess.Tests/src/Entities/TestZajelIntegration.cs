using System;
using System.Collections.Generic;
using Emaratech.Services.Zajel.Common.Tests;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Send;
using Emaratech.Services.Zajel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emaratech.Services.Zajel.DataAccess.Tests.Entities
{
    [TestClass]
    public class TestZajelIntegration
    {
        [TestMethod]
        public void TestEquality()
        {
            var systemId01 = new System.Guid("80322454-E0CE-4B3B-A6B7-8C068DE0FFAA").ToString("N");
            var systemId02 = new System.Guid("D7517218-0295-406D-B81E-2EE0FE279045").ToString("N");

            var zajelInt01 = ZAJELINTEGRATIONHelper.CreateZajelIntegrationRecord(systemId01, "Pera", "38232", "8849813", "3813131", "Popeye", "Dubai Marina", "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52", (int)ProductTypeOptions.EntryPermitSingle, "91227", "Ok", "Everything is fine", "Super!");
            var zajelInt02 = ZAJELINTEGRATIONHelper.CreateZajelIntegrationRecord(systemId01, "Pera", "38232", "8849813", "3813131", "Popeye", "Dubai Marina", "Wall Street, 32", "62321", "26225", (int)DeliveryModeOptions.Dt, "Standard", "52df52", (int)ProductTypeOptions.EntryPermitSingle, "91227", "Ok", "Everything is fine", "Super!");

            var diffList = ZAJELINTEGRATIONHelper.CreateDifferentZajelIntegrationRecords(systemId01, systemId02);

            Assert.AreEqual(zajelInt01, zajelInt02);
            for (int i = 0; i < diffList.Count; i++)
            {
                Assert.AreNotEqual(zajelInt01, diffList[i]);
            }
        }

    }
}
