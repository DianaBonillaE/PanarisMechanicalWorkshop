using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MechanicalLibrary.Domain;
using MechanicalLibrary.Data;

namespace Proyecto2Mechanical.Controllers
{
    [Produces("application/json")]
    [Route("api/vehicle")]
    public class VehicleController : Controller
    {

        private readonly IConfiguration configuration;

        public VehicleController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public void Post([FromBody]Vehicle vehicle)
        {
            VehicleData vehicleData = new VehicleData(configuration.GetConnectionString("MechanicalContext").ToString());
          //  Console.WriteLine(vehicle.ToString());
            vehicleData.Insertar(vehicle);

        }
        [HttpGet]
        public IEnumerable<Vehicle> GetVehicles()
        {
            VehicleData vehicleData = new VehicleData(configuration.GetConnectionString("MechanicalContext").ToString());
            return vehicleData.GetAllVehicles();
        }
    }
}