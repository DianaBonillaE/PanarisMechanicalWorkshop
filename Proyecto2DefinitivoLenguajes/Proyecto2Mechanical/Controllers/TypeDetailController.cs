using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MechanicalLibrary.Domain;
using MechanicalLibrary.Data;

namespace Proyecto2Mechanical.Controllers
{
    [Produces("application/json")]
    [Route("api/typeDetail")]
    public class TypeDetailController
    {
        private readonly IConfiguration configuration;

        public TypeDetailController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<TypeDetail> GetTypes()
        {
            TypeDetailData typeDetailData = new TypeDetailData(configuration.GetConnectionString("MechanicalContext").ToString());
            return typeDetailData.GetAllTypes();
        }
    }
}
