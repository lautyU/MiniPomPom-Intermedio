using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ms_security_token;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SecurityTokenTest
{
    public class SecurityTokenShould
    {
        public class SecurityTokenControllerTests
        {
            protected readonly HttpClient testRequest;
            public SecurityTokenControllerTests()
            {
                var appFactory = new WebApplicationFactory<Startup>();
                testRequest = appFactory.CreateClient();
              
            }
            [Fact]
            public async Task ReturnMethodNotALLOWED()
            {
                var uri = "api/Account/trescreate";
                var data = new ms_security_token.Models.UserInfo { UserName = "fasd", Password = "12345" };
                var datajsonstring = JsonConvert.SerializeObject(data);
                var response = await testRequest.PostAsync(uri, new StringContent(datajsonstring, Encoding.UTF8)
                {
                    Headers = { ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") }
                });
                response.StatusCode.Should().Be(HttpStatusCode.MethodNotAllowed);

            }
            [Fact]
            public async Task ReturnOk()
            {
                var uri = "https://localhost:5001/api/Account/Create";
                var data = new ms_security_token.Models.InputBody { Channel = "admin", Method = "admin1234", Path = "admintw" };
                var datajsonstring = JsonConvert.SerializeObject(data);
                var response = await testRequest.PostAsync(uri, new StringContent(datajsonstring, Encoding.UTF8)
                {
                    Headers = { ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") }
                });
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
           
        }

    }
}

