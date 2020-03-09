using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Register([FromServices]UserManager<ApplicationUser> userManager, [FromBody] RegisterUser registerUser, RegisterPasswordUser registerPasswordUser)
        {

            if (ModelState.IsValid)
            {

                var user = new ApplicationUser(registerUser.FirstName, registerUser.LastName, registerUser.Telephone, registerUser.Email, registerUser.Address);

                var result = await userManager.CreateAsync(user, registerPasswordUser.Password);

                if (result.Succeeded)

                {

                    await SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");

                }

                else

                {

                    AddErrors(result);

                }

            }




            return View(model);





        }
    }
}
