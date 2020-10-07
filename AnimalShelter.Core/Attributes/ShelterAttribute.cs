using AnimalShelter.Core.Attributes.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Attributes
{
    public class ShelterAttribute : ShadowPropertyAttributeBase
    {
        public ShelterAttribute(bool manualRelationConfiguration = false) : base(manualRelationConfiguration)
        { }
    }
}
