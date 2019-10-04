using ConnectVehicle.Data.Interface;
using ConnectVehicle.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectVehicle.Data.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        #region Data
        /// <summary>
        /// Assign value
        /// </summary>
        public List<Vehicle> vehicles = new List<Vehicle>()
        {
            new Vehicle{ CustomerID = 1, VIN = "YS2R4X20005399401", RegNo = "ABC123", Status = "Active"},
            new Vehicle{ CustomerID = 1, VIN = "VLUR4X20009093588", RegNo = "DEF456", Status = "InActive"},
            new Vehicle{ CustomerID = 1, VIN = "VLUR4X20009048066", RegNo = "GHI789", Status = "Active"},


            new Vehicle{ CustomerID = 2, VIN = "YS2R4X20005388011", RegNo = "JKL012", Status = "Active"},
            new Vehicle{ CustomerID = 2, VIN = "YS2R4X20005387949", RegNo = "MNO345", Status = "InActive"},

            new Vehicle{ CustomerID = 3, VIN = "YS2R4X20005387765", RegNo = "PQR678", Status = "Active"},
            new Vehicle{ CustomerID = 3, VIN = "YS2R4X20005387055", RegNo = "STU901", Status = "InActive"}
        };

        public List<Customer> customers = new List<Customer>()
        {
            new Customer{ CustomerID = 1, Name = "Kalles Grustransporter AB", Address = "Cementvägen 8", PostCode = "111 11", City ="Södertälje"},
            new Customer{ CustomerID = 2, Name = "Johans Bulk AB", Address = "Balkvägen 12", PostCode = "222 22", City ="Stockholm"},
            new Customer{ CustomerID = 3, Name = "Haralds Värdetransporter AB", Address = "Budgetvägen 1", PostCode = "333 33", City ="Uppsala"}
        };

        #endregion

        /// <summary>
        /// Get list of vehicles without any contraints
        /// </summary>
        /// <returns>returns list of vehicles</returns>
        public List<Customer> GetAllCustomerVehicles()
        {
            return AssignVehicleList();
        }

        /// <summary>
        /// Get list of vehicles who belongs to
        /// </summary>
        /// <param name="customerID">passing parameter customer id</param>
        /// <returns>returns list of vehicles</returns>
        public List<Vehicle> GetVehicles(int customerID)
        {
            List<Customer> customers = AssignVehicleList();

            var vehicle = customers.Where(c => c.CustomerID == customerID).Select(cus => cus.Vehicles).FirstOrDefault();

            return vehicle.Select(veh => veh).ToList();
        }

        /// <summary>
        /// Get list of vehicles based on status
        /// </summary>
        /// <param name="customerID">passing parameter customer id</param>
        /// <param name="status">passing parameter status</param>
        /// <returns>returns list of vehicles</returns>
        public List<Vehicle> GetVehicles(int customerID, string status)
        {
            List<Customer> customers =  AssignVehicleList();

            var vehicle = customers.Where(c => c.CustomerID == customerID).Select(cus => cus.Vehicles).FirstOrDefault();

            return vehicle.Where(v => v.Status == status).Select(veh => veh).ToList();
        }

        /// <summary>
        /// Set all values in Customer entity
        /// </summary>
        /// <returns></returns>
        private List<Customer> AssignVehicleList()
        {
            IEnumerable<Customer> customerList = customers;

            foreach (var item in customerList)
            {
                item.Vehicles = vehicles.Where(c => c.CustomerID == item.CustomerID).Select(cus => cus).ToList();
            }

            // Return complete customer list with Vehicle value
            return customerList.ToList();
        }
    }
}
