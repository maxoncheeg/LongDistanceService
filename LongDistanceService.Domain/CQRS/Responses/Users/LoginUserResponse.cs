namespace LongDistanceService.Domain.CQRS.Responses.Users;

public record LoginUserResponse(int Id, string Login, string PasswordHash);