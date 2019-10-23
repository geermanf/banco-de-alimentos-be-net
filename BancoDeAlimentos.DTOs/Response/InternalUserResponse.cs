using BancoDeAlimentos.Entities;
using BancoDeAlimentos.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeAlimentos.DTOs
{
    public class InternalUserResponse
    {
        public string Key { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public InternalUserStatus Status { get; set; }

        public DateTime RegisterDate { get; set; }

        public Organization OrganizationInfo { get; set; }

        public bool IsOrganization { get; set; }

    }
}