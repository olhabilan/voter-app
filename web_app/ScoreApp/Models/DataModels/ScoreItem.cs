using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreApp.Models.DataModels
{
    public class ScoreItem
    {
        [BsonElement("supermarketName")]
        public string SupermarketName { get; set; }
        [BsonElement("codeName")]
        public string Code { get; set; }
        [BsonElement("serviceScore")]
        public int ServiceScore { get; set; }
        [BsonElement("overallScore")]
        public int OverallScore { get; set; }
        [BsonElement("priceScore")]
        public int PriceScore { get; set; }
        [BsonElement("scoreDate")]
        public DateTime ScoreDate { get; set; } = DateTime.Now;
        [BsonElement("isProcessed")]
        public bool IsProcessed { get; set; } = false;
    }
}
