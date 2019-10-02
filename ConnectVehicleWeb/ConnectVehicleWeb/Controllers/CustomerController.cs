using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ConnectVehicleWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ConnectVehicleWeb.Controllers
{
    public class CustomerController : Controller
    {
        HttpClient client;
        IConfiguration Configuration { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="configuration"></param>
        public CustomerController(IConfiguration configuration)
        {
            Configuration = configuration;

            client = new HttpClient();
            client.BaseAddress = new Uri(Configuration["JwtAuthentication:ValidIssuer"]);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            /// Credential while accessing WebAPI
            User userModel = new User();
            userModel.username = "scania";
            userModel.password = "secret";

            string stringData = JsonConvert.SerializeObject(userModel);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            /// Get New Token
            HttpResponseMessage response = client.PostAsync ("/api/token/", contentData).Result;
            string stringJWT = response.Content.ReadAsStringAsync().Result;
            JWT jwt = JsonConvert.DeserializeObject<JWT>(stringJWT);
            //HttpContext.Session.SetString("token", jwt.Token);
            TokenSession.Token = jwt.Token;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get customer details
        /// </summary>
        /// <returns></returns>
        // GET: Customer/CustomerDetails
        public ActionResult CustomerDetails()
        {
            return View(GetCustomerDetails());
        }

        /// <summary>
        /// Get vehicle details by customer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            return View(GetVehicleDetails(id));
        }

        /// <summary>
        /// Get list of vehicle using customer ID
        /// </summary>
        /// <param name="customerID">passing customer id</param>
        /// <returns>return list of vehicles</returns>
        private IEnumerable<Vehicle> GetVehicleDetails(int customerID)
        {
            IEnumerable<Vehicle> customers = null;

            using (var client = new HttpClient())
            {
                //HTTP GET
                client.BaseAddress = new Uri(Configuration["JwtAuthentication:ValidIssuer"] + "api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenSession.Token);

                var responseTask = client.GetAsync("vehicle/GetVehicles/" + customerID);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Vehicle>>();
                    readTask.Wait();

                    customers = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    customers = Enumerable.Empty<Vehicle>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return customers;
        }

        /// <summary>
        /// Get list of customers
        /// </summary>
        /// <returns>return list of customer</returns>
        private IEnumerable<Customer> GetCustomerDetails()
        {
            IEnumerable<Customer> customers= null;

            using (var client = new HttpClient())
            {
                //HTTP GET
                client.BaseAddress = new Uri(Configuration["JwtAuthentication:ValidIssuer"] + "api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenSession.Token);

                var responseTask = client.GetAsync("vehicle");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Customer>>();
                    readTask.Wait();

                    customers = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    customers = Enumerable.Empty<Customer>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return customers;
        }
    }

    /// <summary>
    /// JWT Class
    /// </summary>
    public class JWT
    {
        public string Token { get; set; }
    }

    /// <summary>
    /// Store session in static property
    /// </summary>
    public static class TokenSession
    {
        public static string Token { get; set; }
    }
}