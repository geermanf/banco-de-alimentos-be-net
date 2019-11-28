using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeAlimentos.DTOs.Request
{
    public class ConfirmDeliveryRequest
    {
        public string Key { get; set; }

        public bool ExpiredProducts { get; set; }

        public DateTime EffectiveDate { get; set; }
    }
}
