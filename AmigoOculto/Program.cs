using AmigoOculto.Extensios;

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices
builder.Services.AddControllersWithViews();

builder.Services.StringConections();
builder.Services.DependencyInjection();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
