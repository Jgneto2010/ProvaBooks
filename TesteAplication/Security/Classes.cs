﻿namespace TesteAplication.Security
{
    public class User
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }


    public static class Roles
    {
        public const string ROLE_API_PRODUTOS = "Acesso-APIProdutos";
    }

    public class TokenConfigurations
    {
        public int Seconds { get; set; } = 200;
        public string Teste { get; set; }
    }

    public class Token
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }
    }
}
