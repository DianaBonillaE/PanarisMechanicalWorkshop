using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicalLibrary.Data;
using MechanicalLibrary.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Proyecto2Mechanical.Controllers
{
    [Produces("application/json")]
    [Route("api/prueba")]
    public class PruebaController : Controller
    {
        private readonly IConfiguration configuration;

        public PruebaController(IConfiguration configuration)
        {
            this.configuration = configuration;

        }

        [HttpPost]
        public void Post([FromBody]VehicleDetail vehicleDetail)
        {
            VehicleDetailData vehicleDetailData = new VehicleDetailData(configuration.GetConnectionString("MechanicalContext").ToString());
            vehicleDetailData.InsertarDetalleVehiculo(vehicleDetail);
        }



    }
}