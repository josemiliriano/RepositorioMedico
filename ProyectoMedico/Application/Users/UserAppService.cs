using Application.Users.DTOs;
using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Exeptions;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users
{
    public class UserAppService:IUserAppService
    {
        private readonly GeneralRepository<CDUser> _service;
        private readonly MyDataContext _context;
        public UserAppService(GeneralRepository<CDUser> service, MyDataContext context)
        {
            _service = service;
            _context = context;
        }

        public async Task<CDUser> AddUser(UserDto dto)
        {
            try
            {
                var Person = await _context.Persons.FirstOrDefaultAsync(p => p.Identification == dto.Identification);
                if (Person == null)
                {
                    var NewPerson = new CDPerson
                    {
                        Name = dto.Name,
                        LastName = dto.LastName,
                        Address = dto.Address,
                        Phone = dto.Phone,
                        Identification = dto.Identification,
                        Birthday = dto.Birthday
                    };
                    _context.Persons.Add(NewPerson);
                    await _context.SaveChangesAsync();

                }
                var newUser = new CDUser
                {
                    Login = dto.Login,
                    Password = dto.Password,
                    PersonId = Person.IdPerson
                };
                await _service.AddSync(newUser);

                return newUser;
            }
            catch (AlreadyExistsException e)
            {
                throw new(e.Message);
            }
        }       
       
        public async Task DeleteUserAsync(int id)
        {
            var User = await _service.GetById(id);
            if (User != null)
            {
                await _service.DeleteAsync(User);
            }
        }

        public async Task<List<CDUser>> GetAllUser()
        {
            return await _service.GetAll();
        }

        public async Task<List<UserDto>> GetAllUserWhitName(UserDto dto)
        {
            return await _context.Users.Include(u => u.Person).Select(u => new UserDto 
            {
            Login = u.Login,
            Name = u.Person.Name,
            LastName = u.Person.LastName,
            Address = u.Person.Address,
            Phone = u.Person.Phone,
            Identification = u.Person.Identification,
            Birthday = u.Person.Birthday
        }).ToListAsync();
        }

        public async Task<CDUser> GetUserById(int id)
        {
            return await _service.GetById(id);
        }

        public async Task<List<CDUser>> GetUserNoDelete()
        {
            var UserNotDetete = await _service.GetAll();
            return UserNotDetete.Where(u => u.IsDelete=='0').ToList();
        }

        public async Task<CDUser> SoftDelete(int id)
        {
            var User = await _service.GetById(id);
            if (User != null)
            {
                User.IsDelete = '1';                
            }
            await _service.Update(User);
            return User;
        }

        public async Task<CDUser> UpdateUser(int id, UserOnlyDto dto)
        {
            var User = await _service.GetById(id);
            if (User != null)
            {
                User.Login = dto.Login;
                User.Password = dto.Password;
            }
            await _service.Update(User);
            return User;            
        }
    }
}
