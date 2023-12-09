using Microsoft.AspNetCore.Mvc;
using Zhaoxi.NET6Demo.IdentitySer;
using Zhaoxi.NET6Demo.IdentitySer.Utility;

namespace identityServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ICustomJWTService _ICustomJWTService;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, ICustomJWTService iCustomJWTService)
        {
            _logger = logger;
            _ICustomJWTService = iCustomJWTService;
        }

        [HttpGet]
        public IActionResult Login(string name,string password)
        {
            if ("Richard".Equals(name) && "123456".Equals(password))
            {
                //�����ݿ��в�ѯ������
                var user = new CurrentUser()
                {
                    Id = 123,
                    Name = "Richard",
                    Age = 36,
                    NikeName = "���ƽ�ʦRichard��ʦ",
                    Description = ".NET�ܹ�ʦ",
                    RoleList = new List<string>() {
                        "admin",
                        "teacher",
                        "student"
                    }
                };
                //��Ӧ������Token 
                string token = _ICustomJWTService.GetToken(user);
                //string token = string.Empty;
                return new JsonResult(new
                {
                    result = true,
                    token
                });
            }
            else
            {
                return new JsonResult(new
                {
                    result = false,
                    token = ""
                });
            }
        }
    }
}