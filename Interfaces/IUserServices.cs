using estudoRepository.dtos;
using estudoRepository.dtos.UserDTOs;
using estudoRepository.Models;

namespace estudoRepository.Interfaces;

public interface IUserServices
{
  Task<List<User>> GetAll();
  Task<User> GetById(int id);
  Task<User> AddUser(UserDTO user);
  Task<User> UpdateUser(UserUpdateDTO user);
  Task<bool> DeleteUser(int id);
}