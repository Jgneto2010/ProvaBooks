using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TesteAplication.Security;
using TesteAplication.ViewerModel;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiUsuarios.Models;

namespace TesteAplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody]AccessCredentials credenciais,
        [FromServices]AccessManager accessManager)
        {
            if (accessManager.ValidateCredentials(credenciais))
            {
                return accessManager.GenerateToken(credenciais);
            }
            else
            {
                return new
                {
                    Authenticated = false,
                    Message = "Falha ao autenticar"
                };
            }
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<ActionResult> CreateUser([FromServices]UserManager<ApplicationUser> userManager, [FromBody] RegisterUser registerUser, RegisterPasswordUser registerPasswordUser)
        {
            var user = new ApplicationUser(registerUser.FirstName, registerUser.LastName, registerUser.Telephone, registerUser.Email, registerUser.Address);
            var result = await userManager.CreateAsync(user, registerPasswordUser.Password);
           
            if (result.Succeeded)
            {
                return userManager.CreateSecurityTokenAsync(user);
            }
            else
            {
                return BadRequest("Usuário ou senha inválidos");
            }
        }


    }
}

