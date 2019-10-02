using System.Collections.Generic;
using ConnectVehicle.Data.Interface;
using ConnectVehicle.Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectVehicle.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="vehicleRepository"></param>
        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Get all customers and vehicle details
        /// </summary>
        /// <returns>return list of customers</returns>
        [HttpGet]
        [Authorize(JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<Customer>> GetAllCustomerVehicles()
        {
            var vehicleList = _vehicleRepository.GetAllCustomerVehicles();

            if (vehicleList == null)
            {
                return NotFound();
            }

            return Ok(vehicleList);
        }

        /// <summary>
        /// Get vehicle details and filtering with customer id and vehicle status
        /// </summary>
        /// <param name="customerID">passing customer id</param>
        /// <param name="status">passing vehicle status</param>
        /// <returns>return list of vehicle</returns>
        [HttpGet("GetVehicles/{customerID}/{status}")]
        [Authorize(JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<Vehicle>> GetVehicles(int customerID, string status)
        {
            var vehicleList = _vehicleRepository.GetVehicles(customerID, status);

            if (vehicleList == null)
            {
                return NotFound();
            }

            return Ok(vehicleList);
        }

        /// <summary>
        /// Get vehicle details filtering by customer id
        /// </summary>
        /// <param name="customerID">passing customer id</param>
        /// <returns>return list of vehicle</returns>
        [HttpGet("GetVehicles/{customerID}")]
        [Authorize(JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<Vehicle>> GetVehicles(int customerID)
        {
            var vehicleList = _vehicleRepository.GetVehicles(customerID);

            if (vehicleList == null)
            {
                return NotFound();
            }

            return Ok(vehicleList);
        }
    }
}