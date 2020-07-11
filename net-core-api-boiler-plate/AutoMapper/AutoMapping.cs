using AutoMapper;
using net_core_api_boiler_plate.Database.Tables;
using net_core_api_boiler_plate.Models.Responses;

namespace net_core_api_boiler_plate.AutoMapper
{
    /// <summary>
    ///     AutoMapping class
    /// </summary>
    public class AutoMapping : Profile
    {
        /// <summary>
        ///     AutomMapping constructor which creates mapping
        /// </summary>
        public AutoMapping()
        {
            CreateMap<File, FileResponse>();
        }
    }
}