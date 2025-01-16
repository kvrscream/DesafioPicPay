using estudoRepository.dtos;
using estudoRepository.Models;

namespace estudoRepository.Interfaces
{
  public interface IUserRepository
  {
    Task<List<User>> GetAll();
    Task<User> GetById(int id);
    Task<User> AddUser(UserDTO user);
    Task<User> UpdateUser(UserDTO user);
    Task<bool> DeleteUser(int id);
  }
}