
using System.Net;
using System.Text.Json.Serialization;

namespace Entity.MultiDB.Entities.Models.Response;

public abstract class BaseResponseModel
{
    [JsonPropertyName("status")]
    public int Status { get; set; } = (int)HttpStatusCode.OK;

    [JsonPropertyName("message")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }
}
