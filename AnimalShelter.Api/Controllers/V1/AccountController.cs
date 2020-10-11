using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Api.Controllers.V1
{
    [ApiController]
    [Route("v1/[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() =>
            new JsonResult(User.Claims.Select(e => new { value = e.Value, type = e.Type }));
    }
}
