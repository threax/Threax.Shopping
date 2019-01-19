using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Shopping.InputModels;
using Shopping.Database;
using Shopping.ViewModels;

namespace Shopping.Mappers
{
    public partial class AppMapper
    {
        public StoreEntity MapStore(StoreInput src, StoreEntity dest)
        {
            return mapper.Map(src, dest);
        }

        public Store MapStore(StoreEntity src, Store dest)
        {
            return mapper.Map(src, dest);
        }
    }

    public partial class StoreProfile : Profile
    {
        public StoreProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<StoreInput, StoreEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<StoreEntity, Store>());
        }

        void MapInputToEntity(IMappingExpression<StoreInput, StoreEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.StoreId, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.MapFrom<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.MapFrom<IModifiedResolver>());
        }

        void MapEntityToView(IMappingExpression<StoreEntity, Store> mapExpr)
        {
            
        }
    }
}