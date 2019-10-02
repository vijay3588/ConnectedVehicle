/// <summary>
/// Interface for Vehicle 
/// </summary>
/// 
using ConnectVehicle.Data.Models;
using System.Collections.Generic;

namespace ConnectVehicle.Data.Interface
{
    public interface IVehicleRepository
    {
        /// <summary>
        /// Get list of vehicles without any contraints
        /// </summary>
        /// <returns>returns list of vehicles</returns>
        List<Customer> GetAllCustomerVehicles();

        /// <summary>
        /// Get list of vehicles who belongs to
        /// </summary>
        /// <param name="customerID">passing parameter customer id</param>
        /// <returns>returns list of vehicles</returns>
        List<Vehicle> GetVehicles(int customerID);

        /// <summary>
        /// Get list of vehicles based on status
        /// </summary>
        /// <param name="customerID">passing parameter customer id</param>
        /// <param name="status">passing parameter status</param>
        /// <returns>returns list of vehicles</returns>
        List<Vehicle> GetVehicles(int customerID, string status);
    }
}
