using AutoMapper;
using DesafioWebmotors.DesafioOnline;
using DesafioWebmotors.DesafioOnline.Client;
using DesafioWebmotors.DesafioOnline.Impl;
using DesafioWebMotors.Data.Repository;
using DesafioWebMotors.Domain.Interfaces;
using DesafioWebMotors.Domain.Interfaces.Services;
using DesafioWebMotors.Service.Mappings;
using DesafioWebMotors.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioWebMotors.IoC
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IAnuncioWebmotorsRespository), typeof(AnuncioWebmotorsRespository));

            services.AddScoped(typeof(IServiceBase<,,,>), typeof(ServiceBase<,,,>));
            services.AddScoped(typeof(IAnuncioWebmotorsService), typeof(AnuncioWebmotorsService));

            services.AddScoped(typeof(IDesafioOnlineApi), typeof(DesafioOnlineApi));
            services.AddScoped(typeof(IDesafioOnlineClient), typeof(DesafioOnlineClient));

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new DtoToDtoProfile());
            });

            IMapper mapper = configMapper.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
