using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [Route("api/[controller]/[action]")]
    //[controller]: 这是一个占位符，表示控制器名称。在运行时，它将被替换为控制器的实际名称。
    //例如，如果你有一个名为 Ces 的控制器，那么 [controller] 将被替换为 Ces，从而形成路由的一部分。
    //[action]: 同样是一个占位符，表示操作方法的名称。在运行时，它将被替换为实际操作方法的名称
    [ApiController]
    public class Ces : ControllerBase // : ControllerBase 不继承此类 在Controller 也可以
    {
        //[HttpGet] 默认为 api/Ces/GetString 中的Get请求
        [HttpGet("GetString1")]
        //显式指定路由模板为 "GetString"
        //(当[action]没有时 就会指定显示该路由api/Ces/GetString1 , 如果[action]存在 又指定显示路由 就会拼接上 api/Ces/GetString/GetString1  )
        public string GetString() 
        {
            return "123";
        }  
        [HttpPost]
        public async Task<string> PostString() 
        {
            string s = await System.IO.File.ReadAllTextAsync("C:/Users/51138/Desktop/周报.txt");
            return s.Substring(0,20);
        } 
        [HttpGet("GString")]
        public  IActionResult GString(int id)
        //IActionResult 无法推断类型信息 ActionResult<string>泛型 这样写
        //返回IActionResult类型  ok()返回状态码200 NotFound()返回状态码404 注意请求都是成功的
        {
            if (id == 0)
            {
                return Ok(88);
            }
            else 
            {
                return NotFound("id错误");
            }
        }
        [HttpGet("GString2")]
        public  ActionResult<string> GString2(int id)
        //IActionResult 无法推断类型信息 ActionResult<string>泛型 这样写
        {
            if (id == 0)
            {
                return 88.ToString();
            }
            else 
            {
                return NotFound("id错误");
            }
        }
        [HttpGet("{i1}/{i2}")]   // 传递参数  符合rest 语义 
        public string Mulyi(int i1,int i2,string Id)//string Id  也可以混用 Id也是要传的 但不是必要的
        { 
            return i1 + i2 + Id;
        }
    }
}
