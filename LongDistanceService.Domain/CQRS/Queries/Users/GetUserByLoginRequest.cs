﻿using LongDistanceService.Domain.CQRS.Responses.Users;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Users;

public class GetUserByLoginRequest : IRequest<LoginUserResponse?>
{
    public string Login { get; set; } = String.Empty;
}