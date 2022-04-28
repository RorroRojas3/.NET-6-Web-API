﻿using AutoMapper;
using Rodrigo.Rojas.Models.Dtos;
using Rodrigo.Rojas.Repository.Sets;

namespace Rodrigo.Rojas.Models.Mappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<ItemSet, ItemDto>();
        }
    }
}
