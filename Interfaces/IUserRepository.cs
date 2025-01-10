using estudoRepository.Models;

namespace estudoRepository.Interfaces
{
  public interface IUserRepository
  {
    Task<List<User>> GetAll();
    Task<User> GetById(int id);
    Task<User> AddUser(User user);
    Task<User> UpdateUser(User user);
    Task<bool> DeleteUser(int id);
  }
}