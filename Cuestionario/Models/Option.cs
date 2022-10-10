using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Cuestionario.Models
{
    public class Option
    {
        [BsonElement("text")]
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [BsonElement("isCorrect")]
        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
    }
}

