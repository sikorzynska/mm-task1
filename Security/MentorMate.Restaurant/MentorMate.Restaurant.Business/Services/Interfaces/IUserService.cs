﻿using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.Users;

namespace MentorMate.Restaurant.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<GeneralUserModel>> GetAllAsync();
        Task<GeneralUserModel> GetByIdAsync(string id);
        Task<GeneralUserModel> GetByEmailAsync(string email);
        Task<UserResponse> AddUserAsync(AddUserModel model);
        Task<UserResponse> DeleteUserAsync(string id);
        Task<UserResponse> UpdateUserAsync(UpdateUserModel model);
    }
}
