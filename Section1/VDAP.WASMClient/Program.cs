using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VDAP.WASMClient.BAL;
using VDAP.WASMClient.Shared;

namespace VDAP.WASMClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            /*
             * NOTE: This appsettings should be loaded from AppSettings.json. However, we don't do so
             * because finally this will be loading from AppSettings.json from server side
             * This hardcode data population just to demonstrate how the WASM works
             */
            AppGlobalInfo.AppSettings = new AppSettings()
            {
                BusinessName = "Section 1 Client Only", //This will be dynamically show in home page
                APIServiceHost = "https://reqres.in" //This is the address of a free API for testing site
            };
            builder.Services.AddTransient<APIServiceTest>();

            await builder.Build().RunAsync();
        }
    }
}
