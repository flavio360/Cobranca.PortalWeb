using Cobranca.PortalWeb.Mappings;
using Cobranca.PortalWeb.Service;
using Cobranca.PortalWeb.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using AutoMapper;
using Cobranca.PortalWeb.Service.Cobranca;

var builder = WebApplication.CreateBuilder(args);

var HttpClientCobrancaAPIServer = Environment.GetEnvironmentVariable("CobrancaAPI")
    ?? builder.Configuration["ServiceUrls:CobrancaAPI"];

// Serviços
builder.Services.AddControllersWithViews();

// Autenticação por cookie
builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });

#region HttpClient

builder.Services.AddHttpClient<ILoginService, LoginService>(c =>{if (!string.IsNullOrWhiteSpace(HttpClientCobrancaAPIServer))c.BaseAddress = new Uri(HttpClientCobrancaAPIServer);});
builder.Services.AddHttpClient<ICobrancaService, CobrancaService>(c =>{if (!string.IsNullOrWhiteSpace(HttpClientCobrancaAPIServer))c.BaseAddress = new Uri(HttpClientCobrancaAPIServer);});
#endregion

#region Mapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CobrancaProfile>(); // sua Profile precisa herdar de Profile
});

var app = builder.Build();
#endregion


// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // <-- faltava
app.UseAuthorization();

// Rota específica para /Login (opcional)
app.MapControllerRoute(
    name: "login",
    pattern: "Login/{action=Index}/{id?}",
    defaults: new { controller = "Login" });

// Rota padrão que cobre a raiz "/" e quaisquer controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");



app.Run();
