using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace PanarisMechanicalWorkshop.Controllers
{
    [Produces("application/json")]
    [Route("api/workOrder")]
    public class WorkDetailController : Controller
    {
        private readonly IConfiguration configuration;

        public WorkDetailController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

    }
}
