using Intermediary.DaCheng.WebApi.Entity;
using Intermediary.DaCheng.WebApi.Filter;
using Intermediary.DaCheng.WebApi.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceReference;
using System.Linq;

namespace Intermediary.DaCheng.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(NLogFilterAttribute), Order = 1)]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string[] Get()
        {
            WeatherWebServiceSoap weather = new WeatherWebServiceSoapClient(WeatherWebServiceSoapClient.EndpointConfiguration.WeatherWebServiceSoap);
            string[] str = weather.getSupportCity("甘肃");
            if (str != null)
            {
                Department department = new Department();
                department.MC = "内科";
                department.ID = 10547001;
                _logger.LogInformation(JsonHelper.SerializeJson(department));
                //_logger.LogError(str.FirstOrDefault());
                //_logger.LogDebug(str.FirstOrDefault());
                //_logger.LogTrace(str.FirstOrDefault());
                //_logger.LogCritical(str.FirstOrDefault());

                return str;
            }
            else
                return null;
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
