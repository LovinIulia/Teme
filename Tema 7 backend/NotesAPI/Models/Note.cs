using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace NotesAPI.Models
{
    public class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        //[BsonId]
        public string Id { get; set; }
        public string OwnerId { get; set; }
        //[Required] public Guid? OwnerId { get; set; }
    }
}
