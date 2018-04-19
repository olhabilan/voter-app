using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreApp.DataAccess;
using ScoreApp.Models;
using ScoreApp.Models.DataModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreApp.Controllers
{
    public class CodeController : Controller
    {
        [Route("test")]
        [HttpGet]
        public IActionResult Test([FromServices] IRepository<Code> codes, [FromServices] IRepository<Supermarket> sup)
        {
            var gg = codes.SelectAll().First();
            var gg2 = sup.SelectAll().First();

            return Ok();
        }

        [Route("code")]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]string number, [FromServices] DatabaseContext context)
        {
            var supermarketName = await (from codes in context.Codes
                     join supermarkets in context.Supermarkets
                     on codes.SupermarketId equals supermarkets.Id
                     where codes.CodeValue.Equals(number, StringComparison.InvariantCulture)
                     select supermarkets.Name).FirstOrDefaultAsync();

            if(string.IsNullOrEmpty(supermarketName))
                return BadRequest();

            var result = new {
                success = true,
                shop = supermarketName
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