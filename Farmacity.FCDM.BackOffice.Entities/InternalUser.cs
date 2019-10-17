using Farmacity.FCDM.BackOffice.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Farmacity.FCDM.BackOffice.Entities
{
    public class InternalUser
    {
        public InternalUser()
        {
            Key = Guid.NewGuid().ToString();
        }

        [Key]
        public long Id { get; set; }
        public string Key { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public InternalUserStatus Status { get; set; }

        public Organization OrganizationInfo { get; set; }

        public bool IsOrganization { get; set; }

    }
}
