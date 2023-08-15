using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BDOBook.Services.Responses
{
    public class GetMostRecentResponse
    {
        [JsonPropertyName("meta")]
        public Metadata Meta { get; set; }

        [JsonPropertyName("data")]
        public List<Article> Data { get; set; }

        public class Metadata
        {
            [JsonPropertyName("found")]
            public int Found { get; set; }

            [JsonPropertyName("returned")]
            public int Returned { get; set; }

            [JsonPropertyName("limit")]
            public int Limit { get; set; }

            [JsonPropertyName("page")]
            public int Page { get; set; }
        }

        public class Article
        {
            [JsonPropertyName("uuid")]
            public string Uuid { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("keywords")]
            public string Keywords { get; set; }

            [JsonPropertyName("snippet")]
            public string Snippet { get; set; }

            [JsonPropertyName("url")]
            public string Url { get; set; }

            [JsonPropertyName("image_url")]
            public string ImageUrl { get; set; }

            [JsonPropertyName("language")]
            public string Language { get; set; }

            [JsonPropertyName("published_at")]
            public DateTimeOffset PublishedAt { get; set; }

            [JsonPropertyName("source")]
            public string Source { get; set; }

            [JsonPropertyName("categories")]
            public List<string> Categories { get; set; }

            [JsonPropertyName("relevance_score")]
            public double? RelevanceScore { get; set; }

            [JsonPropertyName("locale")]
            public string Locale { get; set; }
        }
    }
}
