using AnimalShelter.Core.Attributes;
using AnimalShelter.Core.Attributes.Base;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AnimalShelter.Infrastructure.Common.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsAnimalTypeEntity(this Type type, out bool manualRelationEnabled) =>
            type.IsShadowPropertyEntity<AnimalTypeAttribute>(out manualRelationEnabled);

        public static bool IsShelterEntity(this Type type, out bool manualRelationEnabled) =>
            type.IsShadowPropertyEntity<ShelterAttribute>(out manualRelationEnabled);

        private static bool IsShadowPropertyEntity<T>(this Type type, out bool manualRelationEnabled)
            where T : ShadowPropertyAttributeBase
        {
            manualRelationEnabled = false;

            var animalTypeAttr = type.GetCustomAttribute<T>();

            if (animalTypeAttr == null)
                return false;

            manualRelationEnabled = animalTypeAttr.ManualRelationConfiguration;

            return true;
        }
    }
}
