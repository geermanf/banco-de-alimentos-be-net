using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Farmacity.Helpers.Extensions
{
    public static class TypeExtensions
    {
        internal const BindingFlags AllInstanceScopes = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        public static T CreateAs<T>(this Type type, params object[] parameters)
        {
            return (T)Activator.CreateInstance(type, AllInstanceScopes, null, parameters, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Determines whether the specified <paramref name="type"/> is a a class and is not abstract.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <paramref name="type"/> is a a class and is not abstract;
        /// 	otherwise, <c>false</c>.
        /// </returns>
        public static bool IsConcreteClass(this Type type)
        {
            if (type == null) return false;

            return type.IsClass && !type.IsAbstract;
        }

        /// <summary>
        /// Similar to the <c>is</c> keyword, which checks if a type is
        /// compatible with the specified <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Is<T>(this Type type)
        {
            return Is(type, typeof(T));
        }

        /// <summary>
        /// Similar to the <c>is</c> keyword, which checks if a type is
        /// compatible with the specified <paramref name="targetType"/>.
        /// </summary>
        /// <param name="type">The </param>
        /// <param name="targetType">The target type.</param>
        /// <returns></returns>
        public static bool Is(this Type type, Type targetType)
        {
            return targetType.IsAssignableFrom(type);
        }

        /// <summary>
        /// Determines whether the <paramref name="type"/> is equal to or derives from the specified <paramref name="baseType"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="baseType">Type of the base.</param>
        /// <returns>
        /// 	<c>true</c> if is equal to or derives from the specified <paramref name="baseType"/>; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method is similar to the <see cref="M:Type.IsSubclassOf"/> method, but with one important distinction:
        /// this method considers generic types.
        /// </remarks>
        public static bool IsOrDerivesFrom(this Type type, Type baseType)
        {
            if (type == null) return false;
            if (baseType == null) return false;

            return type.Is(baseType) || type.DerivesFrom(baseType);
        }

        /// <summary>
        /// Determines whether the <paramref name="type"/> is equal to or derives from the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <typeparam name="TBaseType">Type of the base.</typeparam>
        /// <returns>
        /// 	<c>true</c> if is equal to or derives from the specified <paramref name="type"/>; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method is similar to the <see cref="M:Type.IsSubclassOf"/> method, but with one important distinction:
        /// this method considers generic types.
        /// </remarks>
        public static bool IsOrDerivesFrom<TBaseType>(this Type type)
        {
            return IsOrDerivesFrom(type, typeof(TBaseType));
        }

        /// <summary>
        /// Determines whether the <paramref name="type"/> derives from the specified <paramref name="baseType"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="baseType">Type of the base.</param>
        /// <returns>
        /// 	<c>true</c> if the type derives from the specified <paramref name="baseType"/>; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method is similar to the <see cref="M:Type.IsSubclassOf"/> method, but with one important distinction:
        /// this method considers generic types.
        /// </remarks>
        public static bool DerivesFrom(this Type type, Type baseType)
        {
            if (type == null || baseType == null || type == baseType)
                return false;

            if (type.IsGenericTypeOf(baseType))
                return true;

            if (type.GetInterfaces().Any(i => i.Is(baseType) || i.IsGenericTypeOf(baseType)))
                return true;

            // recurse base types
            while (type.BaseType != null)
            {
                type = type.BaseType;
                if (type.Is(baseType) || type.IsGenericTypeOf(baseType))
                    return true;
            }

            return false;
        }

        public static bool DerivesFrom<TBaseType>(this Type type)
        {
            return type.DerivesFrom(typeof(TBaseType));
        }

        public static bool IsGenericTypeOf(this Type type, Type genericTypeDefinition)
        {
            if (type == null) return false;

            return type.IsGenericType && type.GetGenericTypeDefinition() == genericTypeDefinition;
        }
    }
}