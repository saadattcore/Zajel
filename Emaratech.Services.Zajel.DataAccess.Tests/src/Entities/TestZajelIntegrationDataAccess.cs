using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Emaratech.DatabaseLayer;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Send;
using Emaratech.Services.Zajel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emaratech.Services.Zajel.DataAccess.Tests.Entities
{
    // [TestClass]
    public class TestZajelIntegrationDataAccess
    {
        [TestMethod]
        public void TestQueryWithDataDbContext()
        {
            var sd = ZajelDbProvidersFactory.GetDbContext();
            var address = sd.Set<ZAJELINTEGRATION>().Where(x => x.ID.Equals("e41ebd76e4fe4c9199c59138aedd7466")).ToList();
            Assert.AreEqual(1, address.Count);
        }

        [TestMethod]
        public void TestQueryDataUow()
        {
            var uow = ZajelDbProvidersFactory.GetUnitOfWork();
            var dbData = uow.Repository<ZAJELINTEGRATION>().Get(x => x.ID.Equals("e41ebd76e4fe4c9199c59138aedd7466")).ToList();
            Assert.AreEqual(1, dbData.Count);
        }

        [TestMethod]
        public void TestAddDataUow()
        {            
            var uow = ZajelDbProvidersFactory.GetUnitOfWork();

            var recordNoBefore = uow.Repository<ZAJELINTEGRATION>().Query().Get().Count();
            var zajelEntity = CreateZajelIntegration();
            uow.Repository<ZAJELINTEGRATION>().Insert(zajelEntity);            
            uow.Save();
            var recordNoAfter = uow.Repository<ZAJELINTEGRATION>().Query().Get().Count();
            
            Assert.AreEqual(recordNoBefore+1, recordNoAfter);
        }

        [TestMethod]
        public void TestDeleteDataUow()
        {
            var uow = ZajelDbProvidersFactory.GetUnitOfWork();

            var recordNoBefore = uow.Repository<ZAJELINTEGRATION>().Query().Get().Count();
            var zajelEntity = CreateZajelIntegration();
            uow.Repository<ZAJELINTEGRATION>().Insert(zajelEntity);
            uow.Save();
            uow.Repository<ZAJELINTEGRATION>().Delete(zajelEntity);
            uow.Save();
            var recordNoAfter = uow.Repository<ZAJELINTEGRATION>().Query().Get().Count();

            Assert.AreEqual(recordNoBefore, recordNoAfter);
        }


        [TestMethod]
        public void TestUpdateDataUow()
        {
            string newContantNo = System.Guid.NewGuid().ToString("N");
            var uow1 = ZajelDbProvidersFactory.GetUnitOfWork();
            var uow2 = ZajelDbProvidersFactory.GetUnitOfWork();

            var zajelEntity01 = GetZajelEntity(uow1);

            UpdateContactNo(uow1, zajelEntity01, newContantNo);

            var zajelEntityUpdated = GetZajelEntity(uow2);
            Assert.AreEqual(newContantNo, zajelEntityUpdated.CONTACTNO);

        }

        private ZAJELINTEGRATION GetZajelEntity(IUnitOfWork uow1)
        {
            var zajelEntity = uow1
                .Repository<ZAJELINTEGRATION>()
                .Get(x => x.ID.Equals("d1eb4effb0a742a7b78269417f80b8e1"))
                .First();
            return zajelEntity;
        }

        private ZAJELINTEGRATION CreateZajelIntegration()
        {
            var id = System.Guid.NewGuid();
            var systemId = System.Guid.NewGuid();
            var applicationId = System.Guid.NewGuid();

            var zajelEntity = ZAJELINTEGRATIONHelper.CreateZajelIntegrationRecord(id.ToString("N"), systemId.ToString("N"), applicationId.ToString("N"),
                "8849813", "3813131",
                "Popeye", "Dubai Marina", "Wall Street, 32", "62321", "26", 
                (int)DeliveryModeOptions.Dt, "Standard", "52df52", (int)ProductTypeOptions.EntryPermitSingle, 
                "91227", "Ok", "Everything is fine", "False!");
            zajelEntity.CREATED = DateTime.Now;
            zajelEntity.LASTMODIFIED = DateTime.Now;
            return zajelEntity;
        }

        private void UpdateContactNo(IUnitOfWork uow, ZAJELINTEGRATION zajelEntity, string newContantNo)
        {
            var don = ZajelDbProvidersFactory.GetDbContext();
            var zajEnt01 = don.Set<ZAJELINTEGRATION>().First(x => x.ID.Equals("d1eb4effb0a742a7b78269417f80b8e1"));
            zajEnt01.CONTACTNO = newContantNo;
            var sd = don.SaveChanges();
        }


    }
}