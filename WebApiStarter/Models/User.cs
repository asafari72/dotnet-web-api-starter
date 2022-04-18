using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiStarter.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public List<string> role { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirmCode { get; set; }
        public bool isActivated { get; set; }
        public bool isBanned { get; set; }
        public string banReason { get; set; }

    }
}
