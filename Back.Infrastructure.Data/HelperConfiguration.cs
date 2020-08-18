using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Back.Infrastructure.Data
{
    public static class HelperConfiguration
    {
        public static AppConfiguration GetAppConfiguration(string configurationFile = "App.json")
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile(configurationFile, optional: false).Build();
            var Result = configuration.Get<AppConfiguration>();
            return Result;
    }
    }
}
