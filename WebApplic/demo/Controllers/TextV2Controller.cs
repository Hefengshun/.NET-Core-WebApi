using demo.Utility.Swagger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =false,GroupName =nameof(ApiVersions.V2))] // 这里去配置V2版本
    public class TextV2Controller : ControllerBase
    {
        [HttpGet]
        public Person GetPerson()
        {
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
