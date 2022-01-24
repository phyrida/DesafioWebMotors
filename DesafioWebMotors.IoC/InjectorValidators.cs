using DesafioWebMotors.Domain.Dto;
using DesafioWebMotors.Service.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioWebMotors.IoC
{
    public class InjectorValidators
    {
        public static void RegisterValidators(IServiceCollection services)
        {
            services.AddTransient<IValidator<AnuncioWebmotorsDto>, AnuncioWebmotorsValidator>();
        }
    }
}
