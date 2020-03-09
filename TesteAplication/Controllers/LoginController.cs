using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TesteAplication.Security;
using TesteAplication.ViewerModel;

namespace TesteAplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody]User credenciais,
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
        public async Task<ActionResult> CreateUser([FromServices]UserManager<ApplicationUser> userManager,
                                                   [FromServices]AccessManager accessManager,
                                                   [FromBody] RegisterUser registerPasswordUser)
        {
            var user = new ApplicationUser
            {
                UserName = registerPasswordUser.UserName
            };

            var result =  userManager.CreateAsync(user, registerPasswordUser.Password).Result;
           
            if (result.Succeeded)
            {
                var usuarioSAlvo = userManager.FindByNameAsync(user.UserName).Result;


                var usuarioAcesso = new User();
                usuarioAcesso.UserID = usuarioSAlvo.Id;
                usuarioAcesso.Password = usuarioSAlvo.PasswordHash;

                var resultado = accessManager.GenerateToken(usuarioAcesso);
               return Created($"api/category/{resultado}", new { resultado });
            }
            else
            {
                return BadRequest("Usuário ou senha inválidos");
            }
        }


    }
}

