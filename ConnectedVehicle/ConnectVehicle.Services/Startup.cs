using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectVehicle.Data.Interface;
using ConnectVehicle.Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace ConnectVehicle.Services
{
    public class JwtAuthentication
    {
        public string SecurityKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }

        public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Convert.FromBase64String(SecurityKey));
        public SigningCredentials SigningCredentials => new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
    }

    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1)
                .AddJsonOptions(option =>
                {
                    var resolver = option.SerializerSettings.ContractResolver;

                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                });

            services.AddSingleton<IVehicleRepository, VehicleRepository>();
            //services.Configure<JwtAuthentication>(_configuration.GetSection("JwtAuthentication"));

            // I use PostConfigureOptions to be able to use dependency injection for the configuration
            // For simple needs, you can set the configuration directly in AddJwtBearer()
            //services.AddSingleton<IPostConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = _configuration["JwtAuthentication:ValidIssuer"],
            //            ValidAudience = _configuration["JwtAuthentication:ValidAudience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtAuthentication:SecurityKey"]))
            //        };
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
