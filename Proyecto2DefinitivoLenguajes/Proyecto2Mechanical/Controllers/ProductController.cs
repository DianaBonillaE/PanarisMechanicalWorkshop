using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicalLibrary.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Proyecto2MechanicalApi.Controllers
{
    [Produces("application/json")]
    [Route("api/product")]
    public class ProductController : Controller
    {

        private readonly IConfiguration configuration;
        public ProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public void Post([FromBody]Product product)
        {

        }

    }
}