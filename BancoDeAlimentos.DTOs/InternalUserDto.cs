using BancoDeAlimentos.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeAlimentos.DTOs
{
   public class InternalUserDto
    {
        public string Key { get; set; }
        public string Email { get; set; }
        public String RegisterDate { get; set; }
    }
}
