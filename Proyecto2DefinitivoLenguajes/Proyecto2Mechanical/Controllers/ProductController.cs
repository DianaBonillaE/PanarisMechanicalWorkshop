using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicalLibrary.Data;
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

        [HttpGet("{id:int}", Name = "GetProducts")]
        public IList<Product> Get(int id)
        {
            ProductData workDetailData =
                new ProductData(configuration.GetConnectionString("MechanicalContext").ToString());
            return workDetailData.getAllProductsByIdWorkDetail(id);
        }

        [HttpPost]
        public void Post([FromBody]Product product)
        {
            ProductData productData = new ProductData(configuration.GetConnectionString("MechanicalContext").ToString());

            productData.InsertarProducto(product);
        }

    }
}