using Microsoft.AspNetCore.Mvc;
using ScoreApp.DataAccess;
using ScoreApp.Models;
using System.Linq;

namespace ScoreApp.Controllers
{
    public class CodeController : Controller
    {
        [Route("test")]
        [HttpGet]
        public IActionResult Test()
        {
            var t = new DatabaseContext("server=localhost;UserId=root;Password=1111;database=supermarket_code;SslMode=none");
            var d = new Repository<Code>(t);
            var gg = d.SelectAll().First();

            return Ok();
        }

        [Route("code")]
        [HttpGet]
        public IActionResult Index([FromQuery]string number)
        {
            if (number.Equals("1212"))
            {
                return BadRequest();
            }

            var result = new {
                success = true,
                shop = "Silpo"
            };
            return Json(result);
        }

        [Route("info")]
        [HttpPost]
        public IActionResult Info([FromBody] ShopInfo info)
        {
            var t = info.Mark.Overall;
            return Ok();
        }
    }
}