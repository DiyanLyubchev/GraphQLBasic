using GraphQL.Db.Models;
using GraphQL.DbManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> logger;
        private readonly IGasCarDbManager gasCarDbManager;

        public CarController(ILogger<CarController> logger, IGasCarDbManager gasCarDbManager)
        {
            this.logger = logger;
            this.gasCarDbManager = gasCarDbManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<GasCarTable>>> Get()
        {
            var allCars = await this.gasCarDbManager.GetAllCarsAsync();

            return allCars;
        }
    }
}
