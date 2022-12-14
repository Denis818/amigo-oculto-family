using AmigoOculto.DbContext;
using AmigoOculto.Interfaces;
using AmigoOculto.Models.User;
using AmigoOculto.Repository;
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

        public static void DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ISecretFriend, SecretFriend>();
            services.AddScoped<HttpContextAccessor>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
