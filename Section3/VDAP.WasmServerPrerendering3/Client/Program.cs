using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VDAP.WasmServerPrerendering2.Client.BAL;
using VDAP.WasmServerPrerendering2.Shared;

namespace VDAP.WasmServerPrerendering2.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            //builder.RootComponents.Add<App>("app");
            var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            //Call host service to get the appseting
            AppGlobalInfo.AppSettings = await httpClient.GetFromJsonAsync<AppSettings>("/api/ClientSettings");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddTransient<APIServiceTest>();
            await builder.Build().RunAsync();
        }
    }
}
