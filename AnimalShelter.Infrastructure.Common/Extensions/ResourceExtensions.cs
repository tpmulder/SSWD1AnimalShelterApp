using AnimalShelter.Core.Enums;
using AnimalShelter.Core.Services.Utility.ResourceParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter.Infrastructure.Common.Extensions
{
    public static class ResourceExtensions
    {
        public static IPagedResourceParameters Validate<T>(this IPagedResourceParameters parameters)
        {
            var (validFieds, validIncludes) = GetPropertyNames(typeof(T));

            var validatedResourceParams = parameters.Validate(validFieds, validIncludes);

            parameters.Fields = validatedResourceParams.Fields;
            parameters.Includes = validatedResourceParams.Includes;
            parameters.MainCategory = validatedResourceParams.MainCategory;
            parameters.SearchQuery = validatedResourceParams.SearchQuery;

            if (ValidateElement(parameters.OrderBy, validFieds, out var validatedOrderBy))
                parameters.OrderBy = validatedOrderBy;

            return parameters;
        }

        public static IResourceParameters Validate<T>(this IResourceParameters parameters)
        {
            var (validFieds, validIncludes) = GetPropertyNames(typeof(T));

            return parameters.Validate(validFieds, validIncludes);
        }

        public static bool ValidateIncludes<T>(this string includes, out string validatedIncludes) =>
            ValidateElements(includes, typeof(T).GetProperties().Where(e => e.GetMethod.IsVirtual).Select(e => e.Name), out validatedIncludes);

        private static IResourceParameters Validate(this IResourceParameters parameters, IEnumerable<string> validFields, IEnumerable<string> validIncludes)
        {
            ValidateElements(parameters.Fields, validFields, out var validatedFields);
            ValidateElements(parameters.Includes, validIncludes, out var validatedIncludes);
            ValidateSearchString(parameters.SearchQuery, validFields, out var validatedSearchString);
            ValidateElement(parameters.MainCategory, validFields, out var validatedMainCategory);

            parameters.Fields = validatedFields;
            parameters.Includes = validatedIncludes;
            parameters.MainCategory = validatedMainCategory;
            parameters.SearchQuery = validatedSearchString;

            return parameters;
        }

        private static bool ValidateSearchString(string searchString, IEnumerable<string> validPropNames, out string validatedSearchString)
        {
            validatedSearchString = searchString;

            return true;
        }

        private static bool ValidateElements(string resource, IEnumerable<string> validPropNames, out string validatedElements)
        {
            validatedElements = null;

            if (string.IsNullOrEmpty(resource))
                return false;

            validatedElements = string.Join(",", resource.Split(',').Select(e => e.Trim()).Where(e => ValidateElement(e, validPropNames, out _)));

            return validatedElements.Count() > 0;
        }

        private static bool ValidateElement(string resource, IEnumerable<string> validPropNames, out string validatedElement)
        {
            validatedElement = null;

            if (string.IsNullOrEmpty(resource))
                return false;

            var validProp = validPropNames.FirstOrDefault(e => e.Equals(resource, StringComparison.OrdinalIgnoreCase));

            if (validProp == null)
                return false;

            validatedElement = validProp;

            return true;
        }

        private static (IEnumerable<string> validFieds, IEnumerable<string> validIncludes) GetPropertyNames(Type type)
        {
            var validProps = type.GetType().GetProperties();
            var fieldPropNames = validProps.Where(e => !e.GetMethod.IsVirtual).Select(e => e.Name);
            var relationPropNames = validProps.Where(e => e.GetMethod.IsVirtual).Select(e => e.Name);

            return (fieldPropNames, relationPropNames);
        }
    }
}
