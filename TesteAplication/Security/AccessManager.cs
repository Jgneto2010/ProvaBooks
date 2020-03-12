﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
namespace TesteAplication.Security
{
    public class AccessManager
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;

        public AccessManager(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        public bool ValidateCredentials(User credenciais)
        {
            if (credenciais != null && !String.IsNullOrWhiteSpace(credenciais.UserID))
            {
                // Verifica a existência do usuário nas tabelas do
                // ASP.NET Core Identity
                var userIdentity = _userManager
                    .FindByNameAsync(credenciais.UserID).Result;
                if (userIdentity != null)
                {
                    // Efetua o login com base no Id do usuário e sua senha
                    var resultadoLogin = _signInManager
                        .CheckPasswordSignInAsync(userIdentity, credenciais.Password, false)
                        .Result;


                    return resultadoLogin.Succeeded;
                    //if (resultadoLogin.Succeeded)
                    //{
                    //    //// Verifica se o usuário em questão possui
                    //    //// a role Acesso-APIProdutos
                    //    //credenciaisValidas = _userManager.IsInRoleAsync(
                    //    //    userIdentity, Roles.ROLE_API_PRODUTOS).Result;
                    //}
                }
            }

            return false;
        }

        public Token GenerateToken(User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.UserID, "Login"),
                new[] {
                        //new Claim(JwtRegisteredClaimNames.Jti, user.UserID.ToString("N"),
                        new Claim(JwtRegisteredClaimNames.NameId, user.UserID),

                        ////Nova Claim
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        //Nova Role
                        new Claim(ClaimTypes.Role, "Administrator")

                }
            ); ;

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return new Token()
            {
                Authenticated = true,
                Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                Message = "Ok"
            };
        }
    }
}
