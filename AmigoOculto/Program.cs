using AmigoOculto.Extensios;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices
builder.Services.AddControllersWithViews();

builder.Services.StringConections();
builder.Services.DependencyInjection();

// AspNetUser => essa tabela representa o usário logado
// User => 
// Sugestoes




builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
    //    options.Password.RequiredUniqueChars = 1;

    //name options
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ";
});


// Configure
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
