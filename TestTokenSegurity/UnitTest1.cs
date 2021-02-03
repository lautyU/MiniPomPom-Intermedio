using Microsoft.AspNetCore.Mvc.Testing;
using ms_security_token;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestTokenSegurity
{
    public class CreateTokenServiceTest
    {
        protected readonly HttpClient _cliente;

        public CreateTokenServiceTest()
        {

            var appFactory = new WebApplicationFactory<Startup>();
            _cliente = appFactory.CreateClient();
        }
        [Fact]
        public async Task Create_tokenWithInvalidData()
        {
            var json = new ms_security_token.Models.UserInfo { UserName = "Test", Password = "Contraseña" };
            var jsonserialize = JsonConvert.SerializeObject(json);
            var uri = "";
            var response = await _cliente.PostAsync(uri, new StringContent(jsonserialize, Encoding.UTF8));
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return;
            }
            else
            {
                throw new Exception();
            }

        }
    }
}