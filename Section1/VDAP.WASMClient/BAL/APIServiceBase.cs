using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace VDAP.WASMClient.BAL
{
    public class APIResult<TResponse>
    {
        TResponse Data { get; set; }
        public HttpResponseMessage ResponseMessage { get; set; }
        public async Task<TResponse> GetData()
        {
            if (Data == null)
                Data = await ResponseMessage.Content.ReadFromJsonAsync<TResponse>();
            return Data;
        }
        public TResponse ResponseData
        {
            get
            {
                if (Data == null)
                    Data = ResponseMessage.Content.ReadFromJsonAsync<TResponse>().GetAwaiter().GetResult();
                return Data;
            }
        }

        public APIResult(HttpResponseMessage responseMessage)
        {
            ResponseMessage = responseMessage;
        }
        public APIResult(TResponse data)
        {
            Data = data;
            ResponseMessage = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK, ReasonPhrase = "Data from cache" };
        }
    }

    public class APIServiceBase
    {
        public HttpClient _httpClient;
        public APIServiceBase()
        {
            _httpClient = new HttpClient() { BaseAddress = new Uri(AppGlobalInfo.AppSettings.APIServiceHost) };

            
        }


        protected HttpContent CreatePostContent<T>(T postData)
        {
            var jString = System.Text.Json.JsonSerializer.Serialize<T>(postData);
            return new StringContent(jString, System.Text.Encoding.UTF8, "application/json");
        }

    }
}
