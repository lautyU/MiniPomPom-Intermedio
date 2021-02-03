using Castle.Core.Configuration;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using ms_security_token.Controllers;
using ms_security_token.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ms_security_token_Unitest
{
    public class TokenTest
    {

        public class TokenShould
        {



            //protected readonly IConfiguration _config;

            //public TokenShould(IConfiguration config)
            //{
            //    _config = config;
            //}

            [Fact]
            public async Task beOk()
            {
                var projectDir = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                var configPath = Path.Combine(projectDir, "appsettings.json");
                var builder = new ConfigurationBuilder().AddJsonFile(configPath, optional: false);
                var _configuration = builder.Build();
                var model = new InputBody()
                {
                    Channel = "sucursal",
                    Method = "GET",
                    Path = "minipompom/basic/list"
                };
                var controller = new AccountController(_configuration);
                var result = await controller.BuildToken(model);
                var okResult = result;
                okResult.Should().Be((int)HttpStatusCode.OK);
            }
            [Fact]
            public async Task beBad()
            {
                var projectDir = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                var configPath = Path.Combine(projectDir, "appsettings.json");
                var builder = new ConfigurationBuilder().AddJsonFile(configPath, optional: false);
                var _configuration = builder.Build();
                var model = new InputBody()
                {
                    Channel = "",
                    Method = "",
                    Path = ""
                };
                var controller = new AccountController(_configuration);
                var result = await controller.BuildToken(model);
                var okResult = result;
                okResult.Should().Be((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
