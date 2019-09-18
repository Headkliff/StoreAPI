using AutoMapper;
using Store.Entity.Models;

namespace Store.BL.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserView>();
        }
    }
}
