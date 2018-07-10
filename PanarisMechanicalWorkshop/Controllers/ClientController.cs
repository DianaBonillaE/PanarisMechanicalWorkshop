using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicalLibrary.Domain;
using MechanicalLibrary.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace PanarisMechanicalWorkshop.Controllers
{
    [Produces("application/json")]
    [Route("api/client")]
    public class ClientController : Controller
    {

        private readonly IConfiguration configuration;

        public ClientController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //Get de clientes
        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            ClientData clientData = new ClientData(configuration.GetConnectionString("MechanicalContext").ToString());
            return clientData.GetAllClients();
        }

        [HttpPost]
        public void Post([FromBody]string valor)
        {
            ClientData clientData = new ClientData(configuration.GetConnectionString("MechanicalContext").ToString());
            //clientData.Insertar(valor);
            
        }
    }
}