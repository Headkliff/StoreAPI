using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Store.BL.Models;

namespace Store.BL.Extensions
{
    public static class AddMapper
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

