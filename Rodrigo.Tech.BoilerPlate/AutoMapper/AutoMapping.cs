using AutoMapper;
using Rodrigo.Tech.BoilerPlate.Models.Requests;
using Rodrigo.Tech.BoilerPlate.Models.Responses;
using Rodrigo.Tech.Respository.Tables.Context;
using Rodrigo.Tech.Respository.Tables.Cosmos;

namespace Rodrigo.Tech.BoilerPlate.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<File, FileResponse>();
            CreateMap<ItemRequest, ItemCosmos>();
        }
    }
}