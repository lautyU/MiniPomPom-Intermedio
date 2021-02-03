using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using ms_tree_funcionality;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FunccionalityTest
{
    public class FuncionalityShould
    {
        public class FunctionalityControllerTests
        {
            protected readonly HttpClient testRequest;
            private readonly IConfiguration _config;

            public FunctionalityControllerTests()
            {
                var appFactory = new WebApplicationFactory<Startup>();
                testRequest = appFactory.CreateClient();

            
            
                using (var file = File.OpenText( "\\Users\\axel.lautaro.umansky\\source\\repos\\MiniPomPom-Intermedio\\ms-tree-funcionality\\Properties\\launchSettings.json"))
                {

                        var reader = new JsonTextReader(file);
                    var jObject = JObject.Load(reader);
                    var variables = jObject
                        .GetValue("profiles")
                        //select a proper profile here
                        .SelectMany(profiles => profiles.Children())
                        .SelectMany(profile => profile.Children<JProperty>())
                        .Where(prop => prop.Name == "environmentVariables")
                        .SelectMany(prop => prop.Value.Children<JProperty>())
                        .ToList();

                    foreach (var variable in variables)
                    {
                        Environment.SetEnvironmentVariable(variable.Name, variable.Value.ToString());
                    }
                }
            }
            public class LaunchSettingsFixture : IDisposable
            {
             

                public void Dispose()
                {
                    throw new NotImplementedException();
                }
            }
                [Fact]
                public async Task ReturnOk()
                {
                    var uri = "api/Funcionality";

                    var response = await testRequest.GetAsync(uri);

                    response.StatusCode.Should().Be(HttpStatusCode.OK);
                }
               
                [Fact]
                public async Task ReturnNotFound()
                {
                    var uri = "api/functionality/5544";
                    var response = await testRequest.GetAsync(uri);
                    response.StatusCode.Should().Be(HttpStatusCode.NotFound);
                }


            }
        }
    }

