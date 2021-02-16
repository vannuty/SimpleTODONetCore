using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TODOLib.Entities;
using TODOLib.ViewModels;

namespace TODOLib.Config
{
    public static class AutoMapperProfileConfiguration
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(x =>
            {
                x.CreateMap<TODOEntity, TODODetail>();
                x.CreateMap<TODODetail, TODOEntity>();

                x.CreateMap<TODOEntity, TODOCreate>();
                x.CreateMap<TODOCreate, TODOEntity>();
            });
        }
    }
}
