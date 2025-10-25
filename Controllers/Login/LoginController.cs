using Cobranca.PortalWeb.Models.Login;
using Cobranca.PortalWeb.Service.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace Cobranca.PortalWeb.Controllers.Login
{
    public class LoginController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILoginService _Service;
        private int cacheTime = 10;


        public LoginController(ILoginService service, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _Service = service;
        }
        public IActionResult Index()
        {
            LoginRequestViewModel login = new LoginRequestViewModel();
            return View(login);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Login/Autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] LoginRequestModel loginData)
        {
            try
            {
                var autenticade = await _Service.LoginAutenticacao(loginData);

                if (autenticade != null && autenticade.UsuarioId > 0)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, autenticade.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, autenticade.Nome ?? string.Empty),
                new Claim(ClaimTypes.Email, loginData.Email ?? string.Empty),   // use o tipo certo p/ e-mail
                new Claim("TipoAcesso", autenticade.PerfilId.ToString())
            };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    // Salva o cookie
                    // antes (ERRADO p/ sua config):
                    // await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, ...);

                    // depois (CERTO p/ sua config):
                    await HttpContext.SignInAsync(
                        "CookieAuthentication",
                        principal,
                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                            AllowRefresh = true
                        });


                    // ⚠️ Não use HttpContext.User aqui (ainda é o "antigo").
                    // Monte a chave de cache com dados que você já tem:
                    var cacheKey = $"Login_{autenticade.UsuarioId}";
                    _memoryCache.Set(cacheKey, autenticade,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheTime)));

                    // Gere a rota de forma robusta
                    var url = Url.Action("Index", "Home");   // => "/Home/Index"

                    return Json(new { status = "success", msg = "", urlRedirect = url });
                }
                else
                {
                    var url = Url.Action("Index", "Login");
                    return Json(new { status = "fail", msg = "Usuário ou senha incorretos", urlRedirect = url });
                }
            }
            catch (Exception ex)
            {
                var url = Url.Action("Index", "Login");
                return Json(new { status = "error", msg = $"Erro ao autenticar: {ex.Message}", urlRedirect = url });
            }
        }
    }
}
