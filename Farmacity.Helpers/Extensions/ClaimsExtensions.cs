using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Farmacity.Helpers.Extensions
{
    public static class ClaimsExtensions
    {
        public static Claim GetSubjectId(this IEnumerable<Claim> claims)
        {
            return claims.SingleOrDefault(x => x.Type == "sub");
        }
    }
}
