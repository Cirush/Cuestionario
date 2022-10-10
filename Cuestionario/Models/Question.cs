namespace Cuestionario.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [BsonElement("title")]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [BsonElement("options")]
        [JsonPropertyName("options")]
        public List<Option> Options { get; set; }
    }
}
