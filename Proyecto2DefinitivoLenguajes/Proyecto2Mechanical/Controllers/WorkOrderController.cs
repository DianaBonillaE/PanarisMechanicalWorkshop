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
    [Route("api/workOrder")]
    public class WorkOrderController : Controller
    {
        private readonly IConfiguration configuration;

        public WorkOrderController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IList<WorkOrder> Get()
        {

            WorkOrderData workOrderData =
                new WorkOrderData(configuration.GetConnectionString("MechanicalContext").ToString());
            return workOrderData.GetWorkOrders();
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

    }
}
