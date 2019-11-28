using BancoDeAlimentos.Entities;
using BancoDeAlimentos.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BancoDeAlimentos.DTOs.Request
{
    public class RegisterNewDeliveryRequest
    {
        public string OrganizationKey { get; set; }
        public IEnumerable<ProductRequest> ProductsDeliveries { get; set; }
        public DateTime EstimatedDate { get; set; }
    }
}
