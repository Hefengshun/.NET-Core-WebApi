using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace demo.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 登录控制器
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public LoginReponse Login(LoginRequest req) 
        {
            if (req.UserName == "admin" && req.PassWord == "123456")
            {
                var items = Process.GetProcesses().Select(x =>
                new ProcessInfo(x.Id, x.ProcessName, x.WorkingSet64)
                );
                return new LoginReponse(true, items.ToArray());
            }
            else
            {
                var items = Process.GetProcesses().Select(x =>
               new ProcessInfo(x.Id, x.ProcessName, x.WorkingSet64)
               );
                return new LoginReponse(true, items.ToArray());
            }
        }
    }
    /// <summary>
    /// 接收参数
    /// </summary>
    /// <param name="UserName"></param>
    /// <param name="PassWord"></param>
    public record LoginRequest(string UserName,string PassWord);
    /// <summary>
    /// 信息参数
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Name"></param>
    /// <param name="WorkingSet"></param>
    public record ProcessInfo (long Id,string Name ,long WorkingSet);
    /// <summary>
    /// 返回
    /// </summary>
    /// <param name="ok"></param>
    /// <param name="ProcessInfos"></param>
    public record LoginReponse(bool Ok, ProcessInfo[] ProcessInfos);
}
