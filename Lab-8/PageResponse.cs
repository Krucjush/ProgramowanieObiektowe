using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lab_9
{
    public class PageResponse
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }
        [JsonPropertyName("pagesCount")]
        public int PagesCount { get; set; }
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }
        [JsonPropertyName("batches")]
        public List<SnippetResponse> Batches { get; set; }
    }
}
