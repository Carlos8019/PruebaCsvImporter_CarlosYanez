using System;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace acmeDB.methods
{
    public class ParametersACME
    {
         public string GetJsonAppSetting(string section,string key)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("Parameters.json", optional: true, reloadOnChange: true);
            return builder.Build().GetSection(section).GetSection(key).Value.ToString();
        }      
    }
}
