using BancoDeAlimentos.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BancoDeAlimentos.DTOs
{
    public class ProductDeliveryDto
    {
        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }
}
