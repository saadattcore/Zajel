using System.Collections.Generic;
using AutoMapper;
using Emaratech.Services.Zajel.Common.Tests;
using Emaratech.Services.Zajel.DataAccess.Tests.AppStart.Helpers;
using Emaratech.Services.Zajel.DataAccess.Tests.Entities;
using Emaratech.Services.Zajel.DataAccess.ZajelServiceExternal;
using Emaratech.Services.Zajel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SendModels = Emaratech.Services.Zajel.Contracts.Rest.Models.Send;


namespace Emaratech.Services.Zajel.DataAccess.Tests.AppStart
{
    [TestClass]
    public class TestAutoMapper
    {
        const string ApplicationId = "Pera";
        const string SystemId = "38232";
        const string  ContactNo = "8849813";
        const string  Landline = "3813131";
        const string  SponsorName = "Popeye";
        const string  Area = "Dubai Marina";
        const string  Address = "Wall Street, 32";
        const string  Pobox = "62321";
        const string  OdrStatus = "26225";
        const string  ApplicationType = "Standard";
        const string  FileNo = "52df52";
        const SendModels.ProductTypeOptions ProductType = SendModels.ProductTypeOptions.Residence;
        const SendModels.DeliveryModeOptions DeliveryMode = SendModels.DeliveryModeOptions.Dt;
        readonly System.Guid _userId01Guid = new System.Guid("80322454-E0CE-4B3B-A6B7-8C068DE0FFAA");
        private IMapper _mapper;

        [TestInitialize]
        public void Startup()
        {
            var mapperConfig = new MapperConfiguration(_ => { });
            mapperConfig.Configure();
            mapperConfig.AddMappings();
            _mapper = mapperConfig.CreateMapper();
        }

        [TestMethod]
        public void TestApplicationInfoToZajelIntegrations()
        {            
            var zajelInt = CreateZajelintegrationRecord(Address);
            var appInfo = CreateApplicationInfo();

            // Act
            var output = _mapper.Map<ZAJELINTEGRATION>(appInfo);

            Assert.IsTrue(zajelInt.Equals(output));
            Assert.AreEqual(zajelInt, output);
        }

        [TestMethod]
        public void Test_ZajelIntegrationToVisionDataRequestDto_Equal()
        {
            Test_ZajelIntegrationToVisionDataRequestDto_Common(Address, Address, true);
        }

        [TestMethod]
        public void Test_ZajelIntegrationToVisionDataRequestDto_NotEqual()
        {
            Test_ZajelIntegrationToVisionDataRequestDto_Common(Address, Address + "Diff", false);
        }

        private void Test_ZajelIntegrationToVisionDataRequestDto_Common(string argAddress01, string argAddress02, bool result)
        {
            var zajelInt = CreateZajelintegrationRecord(argAddress01);
            var visionDataExpected = CreateVisionDataRequestDto(argAddress02);

            // Act
            var output = _mapper.Map<VisionDataRequestDTO>(zajelInt);

            // Assert
            Assert.AreEqual(result, visionDataExpected.IsEqual(output));
        }

        [TestMethod]
        public void Test_NullableDecimalToDeliveryOptions_St_Ok()
        {
            Test_NullableDecimalToDeliveryOptions_WithinClass_Common(1, SendModels.DeliveryModeOptions.St);
        }

        [TestMethod]
        public void Test_NullableDecimalToDeliveryOptions_Dt_Ok()
        {
            Test_NullableDecimalToDeliveryOptions_WithinClass_Common(2, SendModels.DeliveryModeOptions.Dt);
        }

        //[ExpectedException(typeof(AutoMapperMappingException))]
        //[TestMethod]
        //public void Test_NullToDeliveryOptions_Dt_Failed()
        //{
        //    Test_NullableDecimalToDeliveryOptions_WithinClass_Common(null, SendModels.DeliveryModeOptions.Dt);
        //}

        //[ExpectedException(typeof(AutoMapperMappingException))]
        //[TestMethod]
        //public void Test_NotInEnumToDeliveryOptions_Dt_Failed()
        //{
        //    Test_NullableDecimalToDeliveryOptions_WithinClass_Common(4, SendModels.DeliveryModeOptions.Dt);
        //}

        public void Test_NullableDecimalToDeliveryOptions_WithinClass_Common(decimal? delMode, SendModels.DeliveryModeOptions delModeEnum)
        {
            var source = new HelperTypeSource() { DELIVERYMODE = delMode };
            var expected = new HelperTypeDest() { DeliveryMode = delModeEnum };
            var output = _mapper.Map<HelperTypeSource, HelperTypeDest>(source);
            
            Assert.AreEqual(expected.DeliveryMode, output.DeliveryMode);
        }

        [TestMethod]
        public void TestEquality_ListOfZajelIntegration_ListOfVisionDataRequestDto_Equals()
        {
            string address01 = Address + "01";
            string address02 = Address + "01";
            var zajelInt01 = CreateZajelintegrationRecord(address01);
            var zajelInt02 = CreateZajelintegrationRecord(address02);
            var listZajInt = new List<ZAJELINTEGRATION>() {zajelInt01, zajelInt02};

            var visionDataExpected01 = CreateVisionDataRequestDto(address01);
            var visionDataExpected02 = CreateVisionDataRequestDto(address02);
            var listVisionDataExpected = new List<VisionDataRequestDTO>() { visionDataExpected01, visionDataExpected02};

            // Act
            var output = _mapper.Map<List<VisionDataRequestDTO>>(listZajInt);

            // Assert
            // This can be done better...Probably by overriding Equality on VisionDataRequestDTO.
            for (int i=0; i<listVisionDataExpected.Count; i++)
            {
                Assert.IsTrue(listVisionDataExpected[i].IsEqual(output[i]));
            }
        }

        /// <summary>
        ///     Just to have at least one property different.
        /// </summary>
        /// <param name="argAddress"></param>
        /// <returns></returns>
        private VisionDataRequestDTO CreateVisionDataRequestDto(string argAddress)
        {
            var visionDataExpected = new VisionDataRequestDTO()
            {
                Address = argAddress,
                Application = ApplicationId,
                Area = Area,
                ApplicationType = ApplicationType,
                ContactNo = ContactNo,
                DeliveryMode = DeliveryMode.ToString(),
                FileNo = FileNo,
                ExtensionData = null,
                LandLineNo = Landline,
                ODRStatus = OdrStatus,
                POBOX = Pobox,
                SponcerName = SponsorName,
                ProductType = (int)ProductType
            };
            return visionDataExpected;
        }

        private ZAJELINTEGRATION CreateZajelintegrationRecord(string argAddress)
        {
            var zajelInt = ZAJELINTEGRATIONHelper.CreateZajelIntegrationRecord(
                null, SystemId, ApplicationId, ContactNo, Landline, SponsorName, Area, argAddress, Pobox, OdrStatus,
                (int) DeliveryMode, ApplicationType, FileNo, (int) ProductType,
                null, null, null, null);
            return zajelInt;
        }

        private SendModels.ApplicationInfo CreateApplicationInfo()
        {
            var appInfo = ApplicationInfoHelpers.CreateApplicationInfo(
                SystemId, ApplicationId, ContactNo, Landline, SponsorName, Area, Address, Pobox, OdrStatus,
                DeliveryMode, ApplicationType, FileNo, ProductType);
            return appInfo;
        }
    }
}