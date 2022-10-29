using AmigoOculto.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AmigoOculto.Extensios
{
    public static class DependencyServices
    {
        public static void StringConections(this IServiceCollection services)
        {
            var configuracao = WebApplication.CreateBuilder();

            var connectionString = configuracao.Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
               options.UseNpgsql(connectionString));

        }

        public static void IdentityDependency(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
