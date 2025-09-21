using Domain.Ports;
using Infraestructure.Data;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            return services;
        }
    }
}
