using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceListNumber.Middware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FuncionalityMiddleware
    {
        private readonly RequestDelegate _next;
        public static SemaphoreSlim semaphore = new SemaphoreSlim(1);
        private static HttpClient httpclient = new HttpClient();
        private readonly IMemoryCache _cache;
        public FuncionalityMiddleware(RequestDelegate next, IMemoryCache cache)
        {
            _next = next;
            _cache = cache;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await semaphore.WaitAsync();
            try
            {
                string cacheEntry;
                if (!_cache.TryGetValue("functionality", out cacheEntry))
                {
                    cacheEntry = await ExecuteRequest();
                    if (cacheEntry == null)
                    {
                        httpContext.Items["response"] = _cache.Get<string>("functionality_no_expiry");
                    }
                    else
                    {
                        var cacheoption = new MemoryCacheEntryOptions()
                             .SetSlidingExpiration(TimeSpan.FromMinutes(10));
                        _cache.Set("functionality", cacheEntry, cacheoption);
                        _cache.Set("functionality_No_Expiry", cacheEntry);
                        httpContext.Items["response"] = _cache.Get<string>("functionality");
                    }
                }
                else
                {
                    httpContext.Items["response"] = _cache.Get<string>("functionality");

                }

            }
            catch (Exception)
            {
                throw;
             }
            semaphore.Release();
            await _next.Invoke(httpContext);
        }
        public static async Task<string> ExecuteRequest()
        {
            HttpResponseMessage result = await httpclient.GetAsync("https://localhost:5001/api/Funcionality");
            if (result.IsSuccessStatusCode)
            {
                var ObjResponse = result.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject(ObjResponse);
                return response.ToString();
            }
            return null;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class FuncionalityMiddlewareExtensions
    {
        public static IApplicationBuilder UseFuncionalityMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FuncionalityMiddleware>();
        }
    }

}



