using AutoMapper;
using Store.Entity.Models;

namespace Store.BL.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserView>();
            CreateMap<UserView, Login>();
            CreateMap<User, Register>();
            CreateMap<Item, ItemView>();
            CreateMap<ItemView, Item>().ForPath(x => x.Type.Name, x => x.MapFrom(z => z.TypeName));
            CreateMap<ItemView, Item>().ForPath(x => x.Category.Name, x => x.MapFrom(z => z.CategoryName));
            CreateMap<ItemType, TypeView>();
            CreateMap<ItemCategory, CategoryView>();
            CreateMap<OrderView, Order>().ForPath(x => x.User.Nickname, x => x.MapFrom(z => z.UserName)); 

        }
    }
}
