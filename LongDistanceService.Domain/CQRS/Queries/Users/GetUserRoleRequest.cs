using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Users;

public record GetUserRoleRequest(int UserId) : IRequest<Roles?>;