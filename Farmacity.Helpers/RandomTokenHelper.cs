using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacity.Helpers
{
    public class RandomTokenHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size">Token length = size * 32</param>
        /// <returns></returns>
        public static string GenerateToken(int size)
        {
            var tokenString = new StringBuilder();

            if (size <= 0)
                return string.Empty;

            for (int i = 0; i < size; i++)
            {
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");

                tokenString.Append(g);
            }

            return tokenString.ToString();
        }
    }
}
