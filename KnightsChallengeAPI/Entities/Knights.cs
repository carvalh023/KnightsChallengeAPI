using MongoDB.Bson.Serialization.Attributes;

namespace KnightsChallengeAPI.Entities
{
    public class Knights
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Birthday { get; set; }

        [BsonElement("Weapons")]
        public Weapons weapons { get; set; }

        [BsonElement("Attributes")]
        public Attributes attributes { get; set; }
        public string KeyAttribute { get; set; }
    }
}
