using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

namespace Farmacity.Helpers.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void AddProfilesFromAssemblyOf<T>(this IMapperConfigurationExpression expression)
        {
            expression.AddProfilesFromAssemblyOf(typeof(T));
        }

        public static void AddProfilesFromAssemblyOf(this IMapperConfigurationExpression expression, Type type)
        {
            var assembly = type.Assembly;

            assembly
                .GetTypes()
                .Where(t => t.Is<Profile>() && t.IsConcreteClass())
                .Each(t => expression.AddProfile(t.CreateAs<Profile>()));
        }

        /// <summary>
        /// Ignores a destination member in the mapping.
        /// </summary>
        /// <typeparam name="TSource">source type</typeparam>
        /// <typeparam name="TDestination">dest type</typeparam>
        /// <typeparam name="TMember">dest member type</typeparam>
        /// <param name="mappingExpression">mapping expression</param>
        /// <param name="destinationMember">the member expression</param>
        /// <returns>
        /// The <paramref name="mappingExpression"/>.
        /// </returns>
        public static IMappingExpression<TSource, TDestination> IgnoreMember<TSource, TDestination, TMember>
        (this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, TMember>> destinationMember)
        {
            return mappingExpression.ForMember(destinationMember, o => o.Ignore());
        }
    }
}
