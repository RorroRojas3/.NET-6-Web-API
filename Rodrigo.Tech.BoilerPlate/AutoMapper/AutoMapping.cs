using AutoMapper;
using Rodrigo.Tech.BoilerPlate.Database.Tables;
using Rodrigo.Tech.BoilerPlate.Database.Tables.Cosmos;
using Rodrigo.Tech.BoilerPlate.Models.Requests;
using Rodrigo.Tech.BoilerPlate.Models.Responses;

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