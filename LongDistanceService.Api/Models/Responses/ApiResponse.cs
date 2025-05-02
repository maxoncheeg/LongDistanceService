namespace LongDistanceService.Api.Models.Responses;

public record ApiResponse(int StatusCode, bool Success, object? Data = null, string Message = "");