using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioWebMotors.IoC
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            InjectorBootStrapper.RegisterServices(services, configuration);
            InjectorValidators.RegisterValidators(services);
        }
    }
}
