using BancoDeAlimentos.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BancoDeAlimentos.Entities
{
    public class ProductDelivery
    {
        [Key]
        public long Id { get; set; }

        public Product Product { get; set; }
        [Required]
        public long ProductId { get; set; }

        public Delivery Delivery { get; set; }
        [Required]
        public long DeliveryId { get; set; }

        public int Quantity { get; set; }
    }
}
