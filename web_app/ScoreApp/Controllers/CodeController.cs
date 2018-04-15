using Microsoft.AspNetCore.Mvc;
using ScoreApp.Models;

namespace ScoreApp.Controllers
{
    public class CodeController : Controller
    {
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