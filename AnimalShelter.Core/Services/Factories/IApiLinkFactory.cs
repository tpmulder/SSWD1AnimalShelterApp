using AnimalShelter.Core.Services.Utility;
using AnimalShelter.Core.Services.Utility.ResourceParams;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Services.Factories
{
    public interface IApiLinkFactory
    {
        public IEnumerable<IApiLink> CreateHateosLinks(IUrlHelper urlHelper, string actionRoute, IPagedResourceParameters resourceParameters, bool hasNext, bool hasPrevious);

        public IEnumerable<IApiLink> CreateHateosLinks(IUrlHelper urlHelper, string actionRoute, Guid itemId, string fields = null);
    }
}
