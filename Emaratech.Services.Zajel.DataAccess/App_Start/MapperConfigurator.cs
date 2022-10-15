using System;
using AutoMapper;
using Emaratech.Services.Common.Entities;
using Emaratech.Services.WcfCommons.Dynamic;
using Emaratech.Services.Zajel.Contracts.Rest.Models.Send;
using Emaratech.Services.Zajel.DataAccess.ZajelServiceExternal;
using Emaratech.Services.Zajel.Entities;
using SendModels = Emaratech.Services.Zajel.Contracts.Rest.Models.Send;
using Emaratech.Services.Zajel.Contracts.Rest.Models;

namespace Emaratech.Services.Zajel.DataAccess
{
    [MapperConfigurationClass]
    public static class MapperConfigurator
    {

        [MapperConfigurationMethod]
        public static void Configure(this IMapperConfiguration configurationExp)
        {

            configurationExp.CreateMap<VersionedEntity<string>, Entity<string>>().ReverseMap();
            configurationExp.CreateMap<ProductTypeOptions, Nullable<decimal>>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(x => (int)x));
            configurationExp.CreateMap<DeliveryModeOptions, Nullable<decimal>>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(x => (int)x));

            configurationExp
                .CreateMap<Nullable<decimal>, DeliveryModeOptions>()
                .ConvertUsing(x => x.ToDeliveryModeOptions());

            configurationExp
                .CreateMap<Nullable<decimal>, string>()
                .ConvertUsing(x => x.ToDeliveryModeOptionsAsString());

            configurationExp.CreateMap<ApplicationInfo, ZAJELINTEGRATION>()
                .ForMember(dest => dest.PRODUCTTYPE, opt => opt.MapFrom(x => (int)x.ProductType))
                .ForMember(dest => dest.DELIVERYMODE, opt => opt.MapFrom(x => (int)x.DeliveryMode))
                .ForMember(dest => dest.APPLICATION_ID, opt => opt.MapFrom(x => x.ApplicationId))
                .ForMember(dest => dest.LANDLINENO, opt => opt.MapFrom(x => x.Landline))
                .ForMember(dest => dest.SYSTEM_KEY, opt => opt.MapFrom(x => x.SystemId));

            configurationExp.CreateMap<ZAJELINTEGRATION, VisionDataRequestDTO>()
                .ForMember(dest => dest.Application, opt => opt.MapFrom(x => x.APPLICATION_ID))
                .ForMember(dest => dest.SponcerName, opt => opt.MapFrom(x => x.SPONSORNAME))
                .ForMember(dest => dest.DeliveryMode, opt => opt.MapFrom(x => x.DELIVERYMODE));


            configurationExp.CreateMap<ZAJELINTEGRATION, ZajelApplication>()
             .ForMember(dest => dest.UniqueId, opt => opt.MapFrom(src => src.ID))
             .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.ADDRESS))
             .ForMember(dest => dest.ApplicationId, opt => opt.MapFrom(src => src.APPLICATION_ID))
             .ForMember(dest => dest.ApplicationType, opt => opt.MapFrom(src => src.APPLICATIONTYPE))
             .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.AREA))
             .ForMember(dest => dest.Awb, opt => opt.MapFrom(src => src.AIRWAYBILLID))
             .ForMember(dest => dest.ContactNo, opt => opt.MapFrom(src => src.CONTACTNO))
             .ForMember(dest => dest.DeliveryMode, opt => opt.MapFrom(src => src.DELIVERYMODE))
             .ForMember(dest => dest.FileNo, opt => opt.MapFrom(src => src.FILENO))
             .ForMember(dest => dest.Landline, opt => opt.MapFrom(src => src.LANDLINENO))
             .ForMember(dest => dest.OdrStatus, opt => opt.MapFrom(src => src.ODRSTATUS))
             .ForMember(dest => dest.PoBox, opt => opt.MapFrom(src => src.POBOX))
             .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.PRODUCTTYPE))
             .ForMember(dest => dest.SponsorName, opt => opt.MapFrom(src => src.SPONSORNAME))
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.RESPONSECURRENTSTATUS));



        }

    }
}