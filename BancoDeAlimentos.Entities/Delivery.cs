using BancoDeAlimentos.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BancoDeAlimentos.Entities
{
    public class Delivery
    {
        public Delivery()
        {
            Key = Guid.NewGuid().ToString();
        }

        [Key]
        public long Id { get; set; }
        public string Key { get; set; }


        [Required]
        public Organization Organization { get; set; }
        public IEnumerable<ProductDelivery> ProductDeliverys { get; set; }
        public DateTime EstimatedDate { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DeliveryStatus Status { get; set; }

        public bool ExpiredProducts { get; set; }
    }
}
