using System;
using System.ComponentModel.DataAnnotations;

namespace Farmacity.FCDM.BackOffice.Configuration
{
    public class ApiInformation
    {
        [Required]
        public string ApiVersion { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string TermOfUse { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        [Required]
        public string ContactWebsite { get; set; }
        [Required]
        public string LicenseName { get; set; }
        [Required]
        public string LicenseWebsite { get; set; }
    }
}
