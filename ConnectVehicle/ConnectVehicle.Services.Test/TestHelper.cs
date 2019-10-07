using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ConnectVehicle.Services.Test
{
    /// <summary>
    /// 
    /// </summary>
    public class TestHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IConfigurationRoot GetIConfigurationRoot()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];

            return new ConfigurationBuilder()
               .SetBasePath(projectPath)
               .AddJsonFile("appsettings.json", optional: true)
               .Build();
        }
    }
}
