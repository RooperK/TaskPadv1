using AutoMapper;
using BL.Models;

namespace API.Models.Mapping
{
    public class TargetModelMapping : Profile
    {
        public TargetModelMapping()
        {
            CreateMap<TargetModelCreate, TargetDto>();
            CreateMap<TargetModel, TargetDto>().ReverseMap();
        }
    }
}