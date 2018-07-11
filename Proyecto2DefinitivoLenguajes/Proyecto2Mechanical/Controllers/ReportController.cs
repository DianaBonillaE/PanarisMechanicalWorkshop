using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Proyecto2MechanicalApi.Controllers
{
    [Produces("application/json")]
    [Route("api/report")]
    public class ReportController : Controller
    {
        private readonly IConfiguration configuration;
        public ReportController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}