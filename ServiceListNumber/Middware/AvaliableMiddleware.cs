using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using ServiceListNumber.Models;
using System.IdentityModel.Tokens.Jwt;
using ServiceListNumber.Middware;

namespace ServiceListNumber.Middware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AvaliableMiddleware
    {
        private readonly RequestDelegate _next;
        private static HttpClient _httpclient = new HttpClient();
        public AvaliableMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                var jsondata = httpContext.Items["response"];
                Root data = JsonConvert.DeserializeObject<Root>((string)jsondata);
                Daywork(data);
            }
            catch (Exception )
            {

                throw;
            }
            await _next(httpContext);
        }
        public void Daywork(Root root)
        {
            var src = DateTime.Now;
            var day = src.DayOfWeek;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);
            var hours = root.data.availability.business_hours.includes;
            int i = 0;
            var j = 0;
            i++;
            if (root.data.availability.business_hours.includes_holidays == true)
            {
                switch (day)
                {
                    case DayOfWeek.Sunday:
                        for (j = 0; j < hours.Count; j++)
                        {
                            var a = hours[j].weekday;
                            a = a.ToUpper();
                            string d = day.ToString();
                            d = d.ToUpper();
                            if (a.Substring(0, 3) == d.Substring(0, 3))
                            {

                                string Fromhourjsonstring = hours[j].from_hour.ToString();
                                string Fromhoutjsonstrinwithnotdot = Fromhourjsonstring.Replace(":", "");

                                string Tohourjsonstring = hours[j].to_hour.ToString();
                                string Tohourjsonstrinwithnotdot = Tohourjsonstring.Replace(":", "");

                                var crafTime = (hm.Hour + ":" + hm.Minute);
                                string timewithnodots = crafTime.Replace(":", "");

                                int hourFromJson = Int32.Parse(Fromhoutjsonstrinwithnotdot);
                                int LocalTime = Int32.Parse(timewithnodots);
                                int TohourJson = Int32.Parse(Tohourjsonstrinwithnotdot);

                                if (hourFromJson < LocalTime && LocalTime < TohourJson)
                                {

                                    break;
                                }
                                else
                                {
                                    throw new Exception("horario no permitido");
                                }
                            }
                        }
                        break;
                    case DayOfWeek.Monday:
                        for (j = 0; j < hours.Count; j++)
                        {
                            var a = hours[j].weekday;
                            a = a.ToUpper();
                            string d = day.ToString();
                            d = d.ToUpper();
                            if (a.Substring(0, 3) == d.Substring(0, 3))
                            {
                                string Fromhourjsonstring = hours[j].from_hour.ToString();
                                string Fromhoutjsonstrinwithnotdot = Fromhourjsonstring.Replace(":", "");

                                string Tohourjsonstring = hours[j].to_hour.ToString();
                                string Tohourjsonstrinwithnotdot = Tohourjsonstring.Replace(":", "");

                                var crafTime = (hm.Hour + ":" + hm.Minute);
                                string timewithnodots = crafTime.Replace(":", "");

                                int hourFromJson = Int32.Parse(Fromhoutjsonstrinwithnotdot);
                                int LocalTime = Int32.Parse(timewithnodots);
                                int TohourJson = Int32.Parse(Tohourjsonstrinwithnotdot);

                                if (hourFromJson < LocalTime && LocalTime < TohourJson)
                                {
                                    break;
                                }
                                else
                                {
                                    throw new Exception("horario no permitido");
                                }
                            }
                        }
                        break;
                    case DayOfWeek.Tuesday:
                        for (j = 0; j < hours.Count; j++)
                        {
                            var a = hours[j].weekday;
                            a = a.ToUpper();
                            string d = day.ToString();
                            d = d.ToUpper();
                            if (a.Substring(0, 3) == d.Substring(0, 3))
                            {
                                string Fromhourjsonstring = hours[j].from_hour.ToString();
                                string Fromhoutjsonstrinwithnotdot = Fromhourjsonstring.Replace(":", "");

                                string Tohourjsonstring = hours[j].to_hour.ToString();
                                string Tohourjsonstrinwithnotdot = Tohourjsonstring.Replace(":", "");

                                var crafTime = (hm.Hour + ":" + hm.Minute);
                                string timewithnodots = crafTime.Replace(":", "");

                                int hourFromJson = Int32.Parse(Fromhoutjsonstrinwithnotdot);
                                int LocalTime = Int32.Parse(timewithnodots);
                                int TohourJson = Int32.Parse(Tohourjsonstrinwithnotdot);

                                if (hourFromJson < LocalTime && LocalTime < TohourJson)
                                {
                                    break;
                                }
                                else
                                {
                                    throw new Exception("horario no permitido");
                                }
                            }
                        }
                        break;
                    case DayOfWeek.Wednesday:

                        for (j = 0; j < hours.Count; j++)
                        {
                            var a = hours[j].weekday;
                            a = a.ToUpper();
                            string d = day.ToString();
                            d = d.ToUpper();
                            if (a.Substring(0, 3) == d.Substring(0, 3))
                            {
                                string Fromhourjsonstring = hours[j].from_hour.ToString();
                                string Fromhoutjsonstrinwithnotdot = Fromhourjsonstring.Replace(":", "");

                                string Tohourjsonstring = hours[j].to_hour.ToString();
                                string Tohourjsonstrinwithnotdot = Tohourjsonstring.Replace(":", "");

                                var crafTime = (hm.Hour + ":" + hm.Minute);
                                string timewithnodots = crafTime.Replace(":", "");

                                int hourFromJson = Int32.Parse(Fromhoutjsonstrinwithnotdot);
                                int LocalTime = Int32.Parse(timewithnodots);
                                int TohourJson = Int32.Parse(Tohourjsonstrinwithnotdot);

                                if (hourFromJson < LocalTime && LocalTime < TohourJson)
                                {
                                    break;
                                }
                                else
                                {
                                    throw new Exception("horario no permitido");
                                }
                            }


                        }
                        break;
                    case DayOfWeek.Thursday:
                        var u = hours[j].weekday.Length;
                        for (j = 0; j < hours.Count; j++)
                        {
                            var a = hours[j].weekday;
                            a = a.ToUpper();
                            string d = day.ToString();
                            d = d.ToUpper();
                            if (a.Substring(0, 3) == d.Substring(0, 3))
                            {
                                string Fromhourjsonstring = hours[j].from_hour.ToString();
                                string Fromhoutjsonstrinwithnotdot = Fromhourjsonstring.Replace(":", "");

                                string Tohourjsonstring = hours[j].to_hour.ToString();
                                string Tohourjsonstrinwithnotdot = Tohourjsonstring.Replace(":", "");

                                var crafTime = (hm.Hour + ":" + hm.Minute);
                                string timewithnodots = crafTime.Replace(":", "");

                                int hourFromJson = Int32.Parse(Fromhoutjsonstrinwithnotdot);
                                int LocalTime = Int32.Parse(timewithnodots);
                                int TohourJson = Int32.Parse(Tohourjsonstrinwithnotdot);

                                if (LocalTime > hourFromJson && LocalTime < TohourJson)
                                {
                                    break;
                                }
                                else
                                {
                                    throw new Exception("horario no permitido");
                                }
                            }


                        }
                        break;
                    case DayOfWeek.Friday:
                        for (j = 0; j < hours.Count; j++)
                        {
                            var a = hours[j].weekday;
                            a = a.ToUpper();
                            string d = day.ToString();
                            d = d.ToUpper();
                            if (a.Substring(0, 3) == d.Substring(0, 3))
                            {
                                string Fromhourjsonstring = hours[j].from_hour.ToString();
                                string Fromhoutjsonstrinwithnotdot = Fromhourjsonstring.Replace(":", "");

                                string Tohourjsonstring = hours[j].to_hour.ToString();
                                string Tohourjsonstrinwithnotdot = Tohourjsonstring.Replace(":", "");

                                var crafTime = (hm.Hour + ":" + hm.Minute);
                                string timewithnodots = crafTime.Replace(":", "");

                                int hourFromJson = Int32.Parse(Fromhoutjsonstrinwithnotdot);
                                int LocalTime = Int32.Parse(timewithnodots);
                                int TohourJson = Int32.Parse(Tohourjsonstrinwithnotdot);

                                if (hourFromJson < LocalTime && LocalTime < TohourJson)
                                {

                                }
                                else
                                {
                                    throw new Exception("horario no permitido");
                                }
                            }


                        }
                        break;
                    case DayOfWeek.Saturday:
                        for (j = 0; j < hours.Count; j++)
                        {
                            var a = hours[j].weekday;
                            a = a.ToUpper();
                            string d = day.ToString();
                            d = d.ToUpper();
                            if (a.Substring(0, 3) == d.Substring(0, 3))
                            {
                                string Fromhourjsonstring = hours[j].from_hour.ToString();
                                string Fromhoutjsonstrinwithnotdot = Fromhourjsonstring.Replace(":", "");

                                string Tohourjsonstring = hours[j].to_hour.ToString();
                                string Tohourjsonstrinwithnotdot = Tohourjsonstring.Replace(":", "");

                                var crafTime = (hm.Hour + ":" + hm.Minute);
                                string timewithnodots = crafTime.Replace(":", "");

                                int hourFromJson = Int32.Parse(Fromhoutjsonstrinwithnotdot);
                                int LocalTime = Int32.Parse(timewithnodots);
                                int TohourJson = Int32.Parse(Tohourjsonstrinwithnotdot);

                                if (hourFromJson < LocalTime && LocalTime > TohourJson)
                                {

                                }
                                else
                                {
                                    throw new Exception("horario no permitido");
                                }
                            }


                        }
                        break;
                    default:
                        {
                            throw new Exception("error");
                        }
                }


            }else
            {
                throw new Exception("esta de vacaciones");
            }
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class AvaliableMiddlewareExtensions
{
    public static IApplicationBuilder UseAvaliableMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AvaliableMiddleware>();
    }
}



