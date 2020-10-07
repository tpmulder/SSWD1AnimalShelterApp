using AnimalShelter.Core.Attributes;
using AnimalShelter.Core.Enums;
using AnimalShelter.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace AnimalShelter.Core.Models
{
    [Shelter]
    public class Restriction : DbModelBase
    {
        public string PropName { get; set; }
        public OperatorEnum Operator { get; set; }
        public string Value { get; set; }
    }
}
