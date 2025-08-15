using System.Diagnostics;
using System.Text.Json.Serialization;

namespace BoardGamesAPI.Model
{
    [DebuggerDisplay("PageNumber : {" + nameof(PageNumber)+ "},PageSize : {" + nameof(PageSize)+ "}")]
    public class PageParameters
    {

        [JsonPropertyName("pageNumber")] //used to map property name to front end
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 5;
    }
}
