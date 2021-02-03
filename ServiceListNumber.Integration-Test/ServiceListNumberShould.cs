using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;




namespace ServiceListNumber.Integration_Test
{
    public class ServicesListNumberTestShould
    {
        public class ServicesListNumberControllerTest
        {
            protected readonly HttpClient testRequest;
            

            private readonly IConfiguration _config;
            public ServicesListNumberControllerTest(IConfiguration config)
            {
                var appFactory = new WebApplicationFactory<Startup>();
                testRequest = appFactory.CreateClient();
                _config = config;
            }
            [Fact]
            public async Task ReturnOK()
             {
                 var uri = "api/ServiceListNumber/basic/list";
                 var response = await testRequest.GetAsync(uri);
                 response.StatusCode.Should().Be(HttpStatusCode.OK);
             }
            [Fact]
            public async Task ReturnNotFound()
            {
                var uri = "api/ServiceListNumber/4";
                var response = await testRequest.GetAsync(uri);
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
          
        }
    }
}