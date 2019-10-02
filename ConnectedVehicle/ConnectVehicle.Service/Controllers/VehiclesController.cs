using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectVehicle.Data.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectVehicle.Service.Controllers
{
    [Route("vehicles/")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="vehicleRepository"></param>
        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var vehicleList = _vehicleRepository.GetAllCustomerVehicles();

            if (vehicleList == null)
            {
                return NotFound();
            }

            return Ok(vehicleList);
        }

    }
}