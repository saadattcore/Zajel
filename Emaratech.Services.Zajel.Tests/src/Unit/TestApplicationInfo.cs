using System;
using System.Collections.Generic;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Send;
using Emaratech.Services.Zajel.Common.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emaratech.Services.Zajel.Tests.Unit
{
    [TestClass]
    public class TestApplicationInfo
    {
        [TestMethod]
        public void TestApplicationInfoEquality()
        {
            var systemId01 = new System.Guid("80322454-E0CE-4B3B-A6B7-8C068DE0FFAA").ToString("N");
            var systemId02 = new System.Guid("D7517218-0295-406D-B81E-2EE0FE279045").ToString("N");

            var appInfo01 = ApplicationInfoHelpers.CreateApplicationInfo("38232", "Pera", "8849813", "3813131", "Popeye", "Dubai Marina", "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52", ProductTypeOptions.EntryPermitSingle);
            var appInfo02 = ApplicationInfoHelpers.CreateApplicationInfo("38232", "Pera", "8849813", "3813131", "Popeye", "Dubai Marina", "Wall Street, 32", "62321", "26225", DeliveryModeOptions.Dt, "Standard", "52df52", ProductTypeOptions.EntryPermitSingle);

            var diffList = ApplicationInfoHelpers.CreateDifferentApplicationInfoRecords(systemId01, systemId02);

            Assert.IsTrue(appInfo01.Equals(appInfo02));
            foreach (var appInfoDifferent in diffList)
            {
                Assert.AreNotEqual(appInfo01, appInfoDifferent);
            }
        }
    }
}
