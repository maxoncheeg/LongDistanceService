using Newtonsoft.Json;

namespace LongDistanceService.Api.Models.Responses;


public class ApiResponse(int statusCode, bool success, object? data = null, string message = "")
{
    [JsonProperty("statusCode")] public int StatusCode { get; set; } = statusCode;
    [JsonProperty("success")] public bool Success { get; set; } = success;
    [JsonProperty("data")] public object? Data { get; set; } = data;
    [JsonProperty("message")] public string Message { get; set; } = message;
}