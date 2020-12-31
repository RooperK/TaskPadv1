using AutoMapper;
using BL.Models.Mapping;

namespace BL.Services
{
    public class BaseService
    {
        protected readonly IMapper Mapper;

        public BaseService(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}