using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Data
{
    public static class ApplicationBuilderExtension
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();            
        }
    }
}
