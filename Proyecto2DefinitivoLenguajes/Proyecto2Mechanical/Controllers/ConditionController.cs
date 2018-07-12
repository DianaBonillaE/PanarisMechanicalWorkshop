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
    [Route("api/condition")]
    public class ConditionController
    {
        private readonly IConfiguration configuration;

        public ConditionController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<Condition> GetConditions()
        {
            ConditionData conditionData = new ConditionData(configuration.GetConnectionString("MechanicalContext").ToString());
            return conditionData.GetAllConditions();
        }
    }
}
