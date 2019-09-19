using AutoMapper;
using Store.Entity.Models;

namespace Store.BL.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserView>();
            CreateMap<UserView,Login>();
            CreateMap<User, Register>();
        }
    }
}
