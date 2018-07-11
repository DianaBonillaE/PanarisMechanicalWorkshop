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
    [Route("api/workDetailOrder")]
    public class WorkDetailController : Controller
    {
        private readonly IConfiguration configuration;

        public WorkDetailController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        [HttpGet("{id:int}", Name = "Get")]
        public IList<WorkDetail> Get(int id)
        {

            WorkDetailData workDetailData =
                new WorkDetailData(configuration.GetConnectionString("MechanicalContext").ToString());
            return workDetailData.GetWorkDetailsByOrder(id);
        }



        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

    }
}