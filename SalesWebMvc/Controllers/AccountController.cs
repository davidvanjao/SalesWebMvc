using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services.Interface;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace SalesWebMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService) //construtor/via injeção de dependência.
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl; //vai guardar o caminho original pra ele ser redirecionado depois do login com sucesso
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null) //verifica se usuario existe
        {
            if(!ModelState.IsValid) //validação do formulário. Se algum campo do LoginViewModel estiver inválido (ex: vazio ou mal formatado), ele retorna a mesma tela com os erros.
            {
                return View(loginViewModel);
            }

            var user = _authService.Authenticate(loginViewModel.Email, loginViewModel.Password);
            if(user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View(loginViewModel);
            }

            //É uma “declaração” sobre o usuário. 
            //Este usuário foi autenticado com cookies e ele tem este email como identificação
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            //Essa linha cria o cookie de autenticação no navegador. É isso que vai manter o usuário logado.
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // Redireciona para o returnUrl, se existir
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            //Redireciona pro Home após login com sucesso
            return RedirectToAction("Index", "Home");


        }

        public async Task<IActionResult> Logout()
        {
            //remove o cookie de autenticação, efetivamente "deslogando" o usuário, e redireciona pra tela de login
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
