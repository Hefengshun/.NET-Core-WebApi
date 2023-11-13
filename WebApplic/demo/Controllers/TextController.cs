using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly ILogger<TextController> _logger;

        public TextController(ILogger<TextController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Person GetPerson()
        {
            _logger.LogError("错误了？？？？？？？？？？？？？？？？？？？"); // 自带的_logger是控制台打印的
            return new Person("heheh", 18);
        }
        [HttpPost]
        public string[] SaveNote(SaveNotRequest req) 
        { 
            System.IO.File.WriteAllText(req.Title+".txt",req.Content);
            return new string[] { "ok",req.Title};
        }
    }
}
