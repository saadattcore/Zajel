using System;
using Emaratech.DatabaseLayer;
using Emaratech.Services.Zajel.Entities;

namespace Emaratech.Services.Zajel.DataAccess.Tests.Entities
{
    public static class ZajelDbProvidersFactory
    {
        public static IDbContext GetDbContext()
        {
            return new ZajelContextUpd();
        }

        public static IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(GetDbContext());
        }
    }
}