using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Auth;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Models;

public record AuthResult(bool UserExists = false, bool IsAuthenticated = false, IUser? User = null) : IAuthResult;