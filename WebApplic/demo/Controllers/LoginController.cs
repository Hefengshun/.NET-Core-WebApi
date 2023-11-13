using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
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
            return new LoginReponse(false,null);
            }
        }
    }
    public record LoginRequest(string UserName,string PassWord);

    public record ProcessInfo (long Id,string Name ,long WorkingSet);
    public record LoginReponse(bool ok, ProcessInfo[] ProcessInfos);
}
