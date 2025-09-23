using Cobranca.PortalWeb.Service;
using Cobranca.PortalWeb.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Globalization;

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

// HttpClient para LoginService (antes do Build)
builder.Services.AddHttpClient<ILoginService, LoginService>(c =>
{
    if (!string.IsNullOrWhiteSpace(HttpClientCobrancaAPIServer))
        c.BaseAddress = new Uri(HttpClientCobrancaAPIServer);
});

var app = builder.Build();

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
