using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        [ResponseCache(Duration = 20)] //客户端 设置缓存20秒 每次请求通后就会缓存20秒
                                       //(在F12控制台那里可以看 大小缓存的会是disk cache 但是浏览器不能禁用缓存 如果禁用了 服务器的缓存也会被禁用)
        [HttpGet]                      // 服务器端 设置缓存的话 多个浏览器读的时候就会直接去读缓存
        public DateTime Get()
        {
            return DateTime.Now;
        }

    }
}
