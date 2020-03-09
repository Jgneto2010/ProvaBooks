using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAplication.ViewerModel
{
    public class RegisterPasswordUser : RegisterUser
    {
        public string Password { get; set; }
        public string ConfirmePassword { get; set; }
    }
}
