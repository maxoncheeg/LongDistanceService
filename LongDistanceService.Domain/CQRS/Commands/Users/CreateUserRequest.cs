﻿using LongDistanceService.Domain.CQRS.Responses.Users;
using LongDistanceService.Domain.Enums;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Users;

public class CreateUserRequest : IRequest<UserResponse?>
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public IList<Roles> Roles { get; set; } = [];
}