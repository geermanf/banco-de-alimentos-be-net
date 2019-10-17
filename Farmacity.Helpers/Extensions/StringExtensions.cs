using System;
using System.Linq;
using System.Text;

namespace Farmacity.Helpers.Extensions
{
    public static class StringExtensions
    {
        static readonly string[] TrueValues = new[] { "1", "yes", "on", bool.TrueString };
        static readonly string[] FalseValues = new[] { "0", "no", "off", bool.FalseString };

        public static bool SafeToBool(this string value, bool defaultValue = false)
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

        public static long SafeToInt64(this string value, long defaultValue = 0, Action<string> failAction = null)
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            long newValue;

            if (!long.TryParse(value, out newValue))
            {
                if (failAction != null)
                    failAction(value);

                return defaultValue;
            }

            return newValue;
        }

        public static int SafeToInt32(this string value, int defaultValue = 0, Action<string> failAction = null)
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            int newValue;

            if (!int.TryParse(value, out newValue))
            {
                if (failAction != null)
                    failAction(value);

                return defaultValue;
            }

            return newValue;
        }

        public static string ToBase64String(this string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            return Convert.ToBase64String(plainTextBytes);
        }

        public static string[] SafeSplit(this string value, char separator, bool removeEmpties = true, bool trim = true)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new string[0];

            var values = value.Split(separator).AsEnumerable();

            if (removeEmpties)
                values = values.Where(x => !string.IsNullOrWhiteSpace(x));

            if (trim)
                values = values.Select(x => x.Trim());

            return values.ToArray();
        }

        public static string EnsureEndsWith(this string input, string value, StringComparison comparison = StringComparison.CurrentCulture)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("value");

            if (!input.EndsWith(value, comparison))
                input += value;

            return input;
        }

        public static string ToCamelCase(this string s)
        {
            if (string.IsNullOrWhiteSpace(s) || char.IsLower(s[0]))
                return s;

            if (s.All(char.IsUpper))
                return s.ToLowerInvariant();

            var chars = s.ToCharArray();

            chars[0] = char.ToLowerInvariant(chars[0]);

            return new string(chars);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotNullOrWhiteSpace(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Corta el string desde la izquierda tantos caracters indicado por maxLength
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string SubStringFromLeft(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value
                   : value.Substring(0, maxLength)
                   );
        }

        /// <summary>
        /// Corta el tring desde la derecha tantos caracteres indicado por maxLength
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string SubStringFromRight(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value
                   : value.Substring(value.Length - maxLength)
                   );
        }

        /// <summary>
        /// Retorna un string del largo indicado por maxLength, si es mas grande lo corta al final
        /// si es mas chico rellena con espacios al inicio
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string PadLeftSubStringFromLeft(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            int spaces = maxLength - value.Length;
            int padLeft = spaces / 2 + value.Length;
            return (value.Length <= maxLength
                   ? value.PadLeft(padLeft)
                   : value.SubStringFromLeft(maxLength)
                   );
        }

        public static string CompleteTextWith(this string value, int maxLength, char caracter, Func<string, char, int, string> funcPad)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            if (value.Length > maxLength)
                return value.SubStringFromLeft(maxLength);

            int len = maxLength - value.Length;
            return funcPad(value, caracter, len);
        }
    }
}