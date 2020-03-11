using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using TesteAplication.Security;
using TesteAplication.ViewerModel;

namespace TesteAplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //Esse metodo valida um usuário e gera um token de acesso
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
        //Esse metodo registra um usuário no sistema gerando seu token de acesso 
        [HttpPost]
        [Route("registerUser")]
        public async Task<ActionResult> CreateUser([FromServices]UserManager<ApplicationUser> userManager,
                                                   [FromServices]AccessManager accessManager,
                                                   [FromBody] RegisterUser registerUser)
        {
            var user = new ApplicationUser
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                PhoneNumber = registerUser.PhoneNumber
                
            };

            var result = userManager.CreateAsync(user, registerUser.Password).Result;



            if (result.Succeeded)
            {
                var usuarioSAlvo = userManager.FindByNameAsync(user.UserName).Result;


                var usuarioAcesso = new User();
                usuarioAcesso.UserID = usuarioSAlvo.Id;
                usuarioAcesso.Password = usuarioSAlvo.PasswordHash;

                //await userManager.AddClaimAsync(user, new Claim("EmployeerName", "_Acesso"));
               
                var resultado = accessManager.GenerateToken(usuarioAcesso);

                
                return  Created($"registerUser/{resultado}", new { resultado });
            }
            else
            {
                return BadRequest("Usuário ou senha inválidos");
            }
            
        }
      

    }
}

