using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacity.FCDM.BackOffice.Entities.Common
{
    public static class GenericExtensions
    {
        public static void ThrowIfNull<T>(this T o, string paramName) where T : class
        {
            if (o == null)
                throw new ArgumentNullException(paramName);
        }

        public static void ThrowIfNullOrEmpty(this string o, string paramName)
        {
            if (o == null)
                throw new ArgumentNullException(paramName);
        }


        public static void ThrowIfNotNull<T>(this T o) where T : class
        {
            if (o != null)
                throw new DuplicateObjectException();
        }

        public static void ThrowIfNull<T>(this T? o, string paramName) where T : struct
        {
            if (!o.HasValue)
                throw new ArgumentNullException(paramName);
        }

        public static void ThrowNotFoundIfNull<T>(this T o) where T : class
        {
            if (o == null)
                throw new ObjectNotFoundException(typeof(T).Name);
        }
    }
}
