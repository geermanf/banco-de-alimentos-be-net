using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeAlimentos.DTOs.Request
{
    public class EditAmountOfPeopleRequest
    {
        public string Key { get; set; }
        public string Children { get; set; }
        public string Adults { get; set; }
    }
}
