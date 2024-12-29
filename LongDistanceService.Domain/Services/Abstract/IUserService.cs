﻿using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Services.Abstract;

public interface IUserService
{
    public Task<bool> CreateUser(string login, string password, string name, string surname, int roleId);
    public Task<bool> ChangePassword(int userId, string oldPassword, string password);
    public Task<IList<IRole>> GetRoles();
}