using FluentValidation;
using Application.Pessoa.Insert;
using Application.Pessoa.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
            });

            services.AddScoped<IValidator<InsertPessoaCommand>, PessoaCommandValidator<InsertPessoaCommand>>();
            services.AddScoped<IValidator<UpdatePessoaCommand>, PessoaCommandValidator<UpdatePessoaCommand>>();

            return services;
        }
    }
}
