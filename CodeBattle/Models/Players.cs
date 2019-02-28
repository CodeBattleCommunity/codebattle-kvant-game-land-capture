using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CodeBattle.Models
{
    public class Players
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Display(Name = "Почта")]
        public string Password { get; set; }
        [Display(Name = "Очки")]
        public int Score { get; set; }
        [Display(Name = "API Key")]
        public int API_Key { get; set; }
    }
}
