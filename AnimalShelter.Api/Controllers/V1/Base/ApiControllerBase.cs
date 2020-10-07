using AnimalShelter.Core.Services.DataAccess;
using AnimalShelter.Core.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterApi.Controllers.V1.Base
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class ApiControllerBase<T> : ControllerBase
        where T : class, IDbModel
    {
        protected readonly IDataAccess<T> _dataService;
        protected readonly ILogger<ApiControllerBase<T>> _logger;

        public ApiControllerBase(IDataAccess<T> dataService, ILogger<ApiControllerBase<T>> logger)
        {
            _logger = logger;
            _dataService = dataService;
        }
    }
}
