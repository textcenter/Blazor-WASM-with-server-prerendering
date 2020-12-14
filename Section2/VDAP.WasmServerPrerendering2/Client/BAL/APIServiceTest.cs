using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VDAP.WasmServerPrerendering2.Client.BAL.Model;

namespace VDAP.WasmServerPrerendering2.Client.BAL
{
    public class APIServiceTest:APIServiceBase
    {
        public async Task<TestModel> GetTestData()
        {
           var rs =   await  _httpClient.GetFromJsonAsync<TestModel>("api/products/1");
            return rs;
        }
    }
}
