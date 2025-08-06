using estudoRepository.Context;
using estudoRepository.dtos;
using estudoRepository.Interfaces;
using estudoRepository.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace estudoRepository.Repositories
{
    public class UserRepository : IUserRepository
    { 
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        { 
          _context = context;
        }

        private void SelectUserType(User user)
        {
            if (user.document.Length > 14)
            {
                user.userType = "PJ";
            }
            else
            {
                user.userType = "PF";
            }
        }

        public async Task<User> AddUser(UserDTO user)
        {

            User userModel = user.Adapt<User>();

            SelectUserType(user: userModel);
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<bool> DeleteUser(int id)
        {
            User user = await this.GetById(id);
            if (user != null) 
            {
              _context.Users.Remove(user);
              await _context.SaveChangesAsync();
              return true;
            }
            return false;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.OrderBy(o => o.name).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<User> UpdateUser(UserDTO user)
        { 
            User data = await this.GetById(user.Id);
            
            if (data != null)
            {
              data.Id = user.Id;
              data.name = user.name;
              data.email = user.email;
              
              await _context.SaveChangesAsync();
              return data;
            }

            return null;
        }
    }
}