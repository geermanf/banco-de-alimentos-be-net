using BancoDeAlimentos.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BancoDeAlimentos.Entities
{
    public class Organization
    {
        public Organization()
        {
            Key = Guid.NewGuid().ToString();
        }

        [Key]
        public long Id { get; set; }
        public string Key { get; set; }


        [Required]
        public string OrganizationName { get; set; }
        public string OrganizationPhone { get; set; }
        public string Children { get; set; }
        public string Adults { get; set; }


        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        public string Reference { get; set; }

        public string OpeningDays { get; set; }

        public string ResponsableFirstName { get; set; }

        public string ResponsableLastName { get; set; }

        public string ResponsableEmail { get; set; }
        public string ResponsablePhone { get; set; }


        [Required]
        public string Status { get; set; }

    }
}
