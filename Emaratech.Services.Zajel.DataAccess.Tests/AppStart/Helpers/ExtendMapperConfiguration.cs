using AutoMapper;

namespace Emaratech.Services.Zajel.DataAccess.Tests.AppStart.Helpers
{
    public static class ExtendMapperConfiguration
    {
        public static void AddMappings(this IMapperConfiguration configurationExp)
        {
            configurationExp.CreateMap<HelperTypeSource, HelperTypeDest>()
                .ForMember(dest => dest.DeliveryMode, opt => opt.MapFrom(x => (decimal?) x.DELIVERYMODE));
        }
    }
}