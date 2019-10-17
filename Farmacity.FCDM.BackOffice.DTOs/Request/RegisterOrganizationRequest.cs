using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacity.FCDM.BackOffice.DTOs.Request
{
    public class RegisterOrganizationRequest
    {
        public string OrganizationName { get; set; }
        public string OrganizationPhone { get; set; }
        public IEnumerable<string> OpenDays { get; set; }
        public int Children { get; set; }
        public int Adults { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Reference { get; set; }
        public string ResponsableFirstName { get; set; }
        public string ResponsableLastName { get; set; }
        public string Password { get; set; }
        public string ResponsableEmail { get; set; }
        public string ResponsablePhone { get; set; }

    }
}
