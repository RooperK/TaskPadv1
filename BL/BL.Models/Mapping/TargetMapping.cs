using AutoMapper;
using DAL.Models;

namespace BL.Models.Mapping
{
    public class TargetMapping : Profile
    {
        public TargetMapping()
        {
            CreateMap<TargetDto, Target>()
                .ForMember(dto => dto.Id, opt 
                    => opt.Ignore());
            CreateMap<Target, TargetDto>();
        }
    }
}