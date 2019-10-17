using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Farmacity.Helpers
{
    public static class ConnectionStringHelper
    {
        private static IConfiguration Configuration { get; set; }
        static readonly string[] TrueValues = new[] { "1", "yes", "on", "si", bool.TrueString };
        static readonly string[] FalseValues = new[] { "0", "no", "off", bool.FalseString };

        public static void SetConfiguration(IConfiguration configurationHandler)
        {
            Configuration = configurationHandler;
        }
        public static string Get(string connectionName, string configKey)
        {
            var connectionString = Configuration.GetConnectionString(connectionName) != null ? Configuration.GetConnectionString(connectionName).ToString() : "";

            connectionString = string.IsNullOrEmpty(connectionString) ? "" : connectionString;

            var isEncrypted = Configuration[configKey].SafeToBool(false);

            return isEncrypted ? EncryptingHelper.Decrypt(connectionString) : connectionString;
        }

        private static bool SafeToBool(this string value, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            value = value.Trim();

            if (TrueValues.Contains(value, StringComparer.OrdinalIgnoreCase))
                return true;
            else if (FalseValues.Contains(value, StringComparer.OrdinalIgnoreCase))
                return false;
            else
                return defaultValue;
        }
    }
}
