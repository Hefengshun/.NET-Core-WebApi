using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{

   
    [ApiController]  // 项目自带的api控制器
    [Route("api/[controller]")] //api/匹配类里面有[controller]的类名 减去controller就是接口的一部分/ [HttpGet(Name = "Forecast")] 中的name名字就是请求地址
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // 获取数据
        //[HttpGet("Forecast")]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        // 获取数据
        [HttpPost("PostData")]
        public string Post2()
        {
           return "123";
        }
    }
}