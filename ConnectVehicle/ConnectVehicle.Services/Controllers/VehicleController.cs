using System.Collections.Generic;
using ConnectVehicle.Data.Interface;
using ConnectVehicle.Data.Models;
using ConnectVehicle.Utility;
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
        [HttpGet, Authorize]
        public ActionResult<List<Customer>> Get()
        {
            // Get all customer along with respective vehicla details
            Logger.Info("Get all customer along with respective vehicla details");
            var vehicleList = _vehicleRepository.GetAllCustomerVehicles();

            if (vehicleList == null)
            {
                Logger.Info("Not Found");
                return NotFound();
            }

            Logger.Info("Respond 'OK'. Got list of customer and vehicle");
            return Ok(vehicleList);
        }

        /// <summary>
        /// Get vehicle details and filtering with customer id and vehicle status
        /// </summary>
        /// <param name="customerID">passing customer id</param>
        /// <param name="status">passing vehicle status</param>
        /// <returns>return list of vehicle</returns>
        [HttpGet("GetVehicles/{customerID}/{status}")]
        public ActionResult<List<Vehicle>> GetVehicles(int customerID, string status)
        {
            Logger.Info("Request GetVehicles. Paasing Params Customer ID - " + customerID + "; Status- " + status);
            var vehicleList = _vehicleRepository.GetVehicles(customerID, status);

            if (vehicleList == null)
            {
                Logger.Info("Not Found");
                return NotFound();
            }

            Logger.Info("Respond 'OK'. Got list of customer and vehicle");
            return Ok(vehicleList);
        }

        /// <summary>
        /// Get vehicle details filtering by customer id
        /// </summary>
        /// <param name="customerID">passing customer id</param>
        /// <returns>return list of vehicle</returns>
        [HttpGet("GetVehicles/{customerID}")]
        public ActionResult<List<Vehicle>> GetVehicles(int customerID)
        {
            Logger.Info("Request GetVehicles. Paasing Params Customer ID - " + customerID );
            var vehicleList = _vehicleRepository.GetVehicles(customerID);

            if (vehicleList == null)
            {
                Logger.Info("Not Found");
                return NotFound();
            }

            Logger.Info("Respond 'OK'. Got list of customer and vehicle");
            return Ok(vehicleList);
        }
    }
}