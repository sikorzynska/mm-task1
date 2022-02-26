﻿using System.Text.Json.Serialization;

namespace MentorMate.Restaurant.Domain.Models.Users
{
    public class UserResponse
    {
        [JsonPropertyName("result")]
        public bool Result { get; set; }
        [JsonPropertyName("message")]
        public string? ResultMessage { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("role")]
        public string? Role { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
