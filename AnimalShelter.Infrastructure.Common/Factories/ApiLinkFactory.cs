using AnimalShelter.Core.Constants;
using AnimalShelter.Core.Enums;
using AnimalShelter.Core.Services.Factories;
using AnimalShelter.Core.Services.Utility;
using AnimalShelter.Core.Services.Utility.ResourceParams;
using AnimalShelter.Infrastructure.Common.Utility;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace AnimalShelter.Infrastructure.Common.Factories
{
    public class ApiLinkFactory : IApiLinkFactory
    {
        public IEnumerable<IApiLink> CreateHateosLinks(IUrlHelper urlHelper, string actionRoute, Guid itemId, string fields = null)
        {
            dynamic queryParams = new ExpandoObject();

            if (!string.IsNullOrEmpty(fields))
                queryParams.fields = fields;

            queryParams.id = itemId;

            var links = new List<ApiLink>
            {
                CreateItemLink(HttpMethod.Get, HateosConstants.Self, urlHelper.Link(actionRoute, queryParams)),
                CreateItemLink(HttpMethod.Post, HttpMethod.Post.Method.ToLower(), urlHelper.Link(actionRoute, null)),
                CreateItemLink(HttpMethod.Delete, HttpMethod.Delete.Method.ToLower(), urlHelper.Link(actionRoute, new { queryParams.id })),
                CreateItemLink(HttpMethod.Put, HttpMethod.Put.Method.ToLower(), urlHelper.Link(actionRoute, new { queryParams.id }))
            };

            return links;

            static ApiLink CreateItemLink(HttpMethod method, string rel, string route) =>
                new ApiLink(rel, route, method.Method);
        }

        public IEnumerable<IApiLink> CreateHateosLinks(IUrlHelper urlHelper, string actionRoute, IPagedResourceParameters resourceParameters, bool hasNext, bool hasPrevious)
        {
            var links = new List<IApiLink>();
            var httpMethod = HttpMethod.Get.Method;

            links.Add(CreatePagedResourceLink(urlHelper, actionRoute, resourceParameters, PagedResourceUriType.Current, httpMethod));

            if (hasNext)
                links.Add(CreatePagedResourceLink(urlHelper, actionRoute, resourceParameters, PagedResourceUriType.NextPage, httpMethod));

            if (hasPrevious)
                links.Add(CreatePagedResourceLink(urlHelper, actionRoute, resourceParameters, PagedResourceUriType.PreviousPage, httpMethod));

            return links;

            static IApiLink CreatePagedResourceLink(IUrlHelper urlHelper, string actionRoute, IPagedResourceParameters resourceParams, PagedResourceUriType uriType, string httpMethod) =>
                new ApiLink(CreatePagedResourceUri(urlHelper, actionRoute, resourceParams, uriType),
                    uriType == PagedResourceUriType.Current ? HateosConstants.Self : uriType.ToString().Camelize(), httpMethod);

            static string CreatePagedResourceUri(IUrlHelper urlHelper, string actionRoute, IPagedResourceParameters resourceParameters, PagedResourceUriType type)
            {
                var pageNum = type switch
                {
                    PagedResourceUriType.NextPage => resourceParameters.PageNumber + 1,
                    PagedResourceUriType.PreviousPage => resourceParameters.PageNumber - 1,
                    _ => resourceParameters.PageNumber
                };

                return urlHelper.Link(actionRoute,
                    new
                    {
                        fields = resourceParameters.Fields,
                        orderBy = resourceParameters.OrderBy,
                        pageNumber = pageNum,
                        mainCategory = resourceParameters.MainCategory,
                        searchQuery = resourceParameters.SearchQuery
                    });
            }
        }
    }
}
