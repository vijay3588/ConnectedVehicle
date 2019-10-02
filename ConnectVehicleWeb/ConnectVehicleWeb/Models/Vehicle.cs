
namespace ConnectVehicleWeb.Models
{
    public class Vehicle
    {
        /// <summary>
        /// Vehicle ID
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Registration Number
        /// </summary>
        public string RegNo { get; set; }

        /// <summary>
        /// Vehicle Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Customer ID
        /// </summary>
        public int CustomerID { get; set; }
    }
}
