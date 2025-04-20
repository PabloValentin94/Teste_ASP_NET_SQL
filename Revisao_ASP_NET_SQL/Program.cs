using Microsoft.EntityFrameworkCore;

using Revisao_ASP_NET_SQL.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurando a aplicação para o uso do MySQL.

var connection_string = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Application_DB_Context>(options =>
{

    options.UseMySql(connection_string, ServerVersion.AutoDetect(connection_string));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
