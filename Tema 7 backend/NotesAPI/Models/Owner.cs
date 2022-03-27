using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace NotesAPI.Models
{
    public class Owner
    {
        [BsonId]
        public string Id { get; set; }
        
        public string Name { get; set; }
    }
}
