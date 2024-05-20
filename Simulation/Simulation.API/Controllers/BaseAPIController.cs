﻿using Microsoft.AspNetCore.Mvc;

namespace Simulation.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BaseAPIController : Controller
    {
    }
}
