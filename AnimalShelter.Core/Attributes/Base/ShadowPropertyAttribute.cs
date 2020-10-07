using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Attributes.Base
{
    public abstract class ShadowPropertyAttributeBase : Attribute
    {
        public bool ManualRelationConfiguration { get; }

        public ShadowPropertyAttributeBase(bool manualRelationConfiguration = false)
        {
            ManualRelationConfiguration = manualRelationConfiguration;
        }
    }
}
