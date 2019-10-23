using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeAlimentos.DTOs.Request
{
    public class InternalUserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
