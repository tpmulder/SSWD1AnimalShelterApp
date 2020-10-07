using AnimalShelter.Core.Attributes.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Attributes
{
    public class AnimalTypeAttribute : ShadowPropertyAttributeBase
    {
        public AnimalTypeAttribute(bool manualRelationConfiguration = false) : base(manualRelationConfiguration)
        { }
    }
}
