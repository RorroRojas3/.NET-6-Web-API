using AutoMapper;
using net_core_api_boiler_plate.Database.Tables;
using net_core_api_boiler_plate.Models.Responses;

namespace net_core_api_boiler_plate.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<File, FileResponse>();
        }
    }
}