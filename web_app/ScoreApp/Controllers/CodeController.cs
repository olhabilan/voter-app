using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreApp.DataAccess;
using ScoreApp.Models;
using ScoreApp.Models.DataModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.Extensions.Logging;

namespace ScoreApp.Controllers
{
    public class CodeController : Controller
    {
        [Route("poll")]
        [HttpGet]
        public IActionResult Poll()
        {
            return File("~/index.html", "text/html");
        }

        [Route("test")]
        [HttpGet]
        public IActionResult Test([FromServices] IRepository<Code> codes, [FromServices] IRepository<Supermarket> sup, [FromServices] IMongoContext mongo)
        {
            mongo.ScoreItems.InsertOne(new ScoreItem() { Code = "test2", OverallScore = 3, PriceScore = 3, ServiceScore = 3, SupermarketName = "yo" });
            
            //var client = new MongoClient("mongodb://localhost:27017");
            // var database = client.GetDatabase("result");
            //var t = database.GetCollection<ScoreItem>("scoreCollection");
            //t.InsertOne(new ScoreItem() { Code = "test", OverallScore = 3, PriceScore = 3, ServiceScore = 3, SupermarketName = "yo" });

            //var gg = codes.SelectAll().First();
            //var gg2 = sup.SelectAll().First();

            return Ok();
        }

        [Route("code")]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]string number,
            [FromServices] DatabaseContext context,
            [FromServices] ILogger<CodeController> logger)
        {
            string supermarketName = null;
            logger.LogInformation("Query mysql, code: {number}", number);

            try
            {
                supermarketName = await (from codes in context.Codes
                                         join supermarkets in context.Supermarkets
                                         on codes.SupermarketId equals supermarkets.Id
                                         where codes.CodeValue.Equals(number, StringComparison.InvariantCulture)
                                         select supermarkets.Name).FirstOrDefaultAsync();
            }
            catch (Exception ex) {
                logger.LogError(ex, "Failed to request my sql");
            }
            

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
        public async Task<IActionResult> Info([FromBody] ShopInfo info,
            [FromServices] IMongoContext mongo,
            [FromServices] ILogger<CodeController> logger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("incorrect model");
            }

            logger.LogInformation("Inserting row into mongo");
            try
            {
                await mongo.ScoreItems.InsertOneAsync(new ScoreItem()
                {
                    Code = info.Code,
                    SupermarketName = info.Shop,
                    OverallScore = info.Mark.Overall,
                    PriceScore = info.Mark.Price,
                    ServiceScore = info.Mark.Service
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to insert row into mongo db");
            }

            return Ok();
        }
    }
}