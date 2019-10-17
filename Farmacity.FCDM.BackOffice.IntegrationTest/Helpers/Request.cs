using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Farmacity.FCDM.BackOffice.IntegrationTest.Helpers
{
    public class Request<TStartup> : IDisposable where TStartup : class
    {
        private readonly HttpClient client;
        private readonly TestServer server;

        public Request()
        {
            var webHostBuilder = new WebHostBuilder().UseStartup<TStartup>();
            server = new TestServer(webHostBuilder);
            client = server.CreateClient();
        }


        public Task<HttpResponseMessage> Get(string url)
        {
            return client.GetAsync(url);
        }
        
        public Task<HttpResponseMessage> Post<T>(string url, T body)
        {
            return client.PostAsJsonAsync<T>(url, body);
        }

        public Task<HttpResponseMessage> Put<T>(string url, T body)
        {
            return client.PutAsJsonAsync<T>(url, body);
        }

        public Task<HttpResponseMessage> Delete(string url)
        {
            return client.DeleteAsync(url);
        }

        public void Dispose()
        {
            client.Dispose();
            server.Dispose();
        }
    }
}