namespace LongDistanceService.Domain.CQRS.Responses.Users;

public record UserResponse(int Id, string Login, string PasswordHash);