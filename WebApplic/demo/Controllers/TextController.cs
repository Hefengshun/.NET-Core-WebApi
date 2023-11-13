using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
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
