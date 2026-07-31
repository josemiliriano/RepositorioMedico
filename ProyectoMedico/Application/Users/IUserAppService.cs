using Application.Users.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users
{
    public interface IUserAppService
    {
        public Task<UserDto> AddUser(UserDto dto);
        public Task<List<CDUser>> GetAllUser();
        public Task<CDUser> GetUserById(int id);
        public Task<CDUser> SoftDelete(int id);
        public Task<List<CDUser>> GetUserNoDelete();
        public Task DeleteUserAsync(int id);
        public Task<CDUser> UpdateUser(int id, UserOnlyDto dto);
        public Task<List<UserDto>> GetAllUserWhitName();
    }
}
