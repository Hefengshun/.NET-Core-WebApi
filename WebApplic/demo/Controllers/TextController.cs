using demo.Utility.Fliters;
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
        [CustomResourceFilter]  // 自定义 CustomResourceFilterAttribute 可以不写Attribute
                                // 执行在TextController构造函数之前  把其包裹起来了
        public Person GetPerson()
        {
            _logger.LogInformation("错误了？？？？？？？？？？？？？？？？？？？"); // 自带的_logger是控制台打印的
            return new Person("heheh", 18);
        }
        [HttpPost]
        //[CustomAsyncResourceFilter]
        //[CustomCacheResourceFilter]  // 扩展缓存
        [CustomCacheAsyncResourceFilter]  // 异步扩展缓存
        public string[] SaveNote(SaveNotRequest req) 
        { 
            System.IO.File.WriteAllText(req.Title+".txt",req.Content);
            return new string[] { "ok",req.Title};
        }
    }
}
