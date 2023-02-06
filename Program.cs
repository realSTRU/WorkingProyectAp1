using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RegistroPrestamosAp1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var ConStr = builder.Configuration.GetConnectionString("ConStr");

//Inyeccion de las BLLS
builder.Services.AddScoped<OcupacionesBLL>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
IServerSideBlazorBuilder serverSideBlazorBuilder = builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<Contexto>(options=>options.UseSqlite(ConStr));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
