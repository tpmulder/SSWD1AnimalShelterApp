using AnimalShelter.Core.Constants;
using AnimalShelter.Core.Services.Utility;
using AnimalShelter.Infrastructure.Common.Utility;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace AnimalShelter.Infrastructure.Common.Extensions
{
    public static class DynamicDataExtensions
    {
        public static IEnumerable<IApiLink> GetHateosLinks(this object obj) =>
            (IEnumerable<ApiLink>)obj.GetValueOfProperty(HateosConstants.LinksProperty);

        public static void Shape(this object source, IEnumerable<string> fields, IEnumerable<IApiLink> hateosLinks = null)
        {
            var obj = new ExpandoObject();
            var properties = GetPropertiesByName(source.GetType(), fields);

            if (hateosLinks != null || hateosLinks.Count() < 1)
                obj.AddPropertyWithValue(HateosConstants.LinksProperty, hateosLinks);

            properties.ToList().ForEach(e => obj.AddPropertyWithValue(e.Name, source.GetValueOfProperty(e)));
        }

        public static void AddLinks(this ExpandoObject source, IEnumerable<IApiLink> links) =>
            source.AddPropertyWithValue("links", links);

        public static IEnumerable<ExpandoObject> ToExpandoObjectList<T>(this IEnumerable<T> list) =>
            list.Select(ToExpandoObject);

        public static ExpandoObject ToExpandoObject<T>(this T obj)
        {
            var expObj = new ExpandoObject();

            foreach (var prop in obj.GetType().GetProperties())
                ((IDictionary<string, object>)expObj).Add(prop.Name, obj.GetValueOfProperty(prop));

            return expObj;
        }

        public static void AddPropertyWithValue(this ExpandoObject source, string name, object value) =>
            ((IDictionary<string, object>)source).Add(name, value);

        public static object GetValueOfProperty(this object source, string propName) =>
            source.GetValueOfProperty(source.GetType().GetProperty(propName));

        public static object GetValueOfProperty(this object source, PropertyInfo property) =>
            Expression.Lambda<Func<object>>(
                Expression.Convert(
                    Expression.PropertyOrField(
                        Expression.Constant(source, source.GetType()), property.Name), property.PropertyType)).Compile()();

        private static IEnumerable<PropertyInfo> GetPropertiesByName(this Type type, IEnumerable<string> fields) =>
            type.GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                .Where(e => fields.Any(f => f.Equals(e.Name, StringComparison.OrdinalIgnoreCase)))
                .ToList();
    }
}
