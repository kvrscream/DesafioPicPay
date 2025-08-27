using estudoRepository.dtos;
using estudoRepository.dtos.UserDTOs;
using estudoRepository.Interfaces;
using estudoRepository.Models;

namespace estudoRepository.Services;

public class UserServices : IUserServices
{
  private readonly IUserRepository _repository;

  public UserServices(IUserRepository repository)
  {
    _repository = repository;
  }

  public async Task<User> AddUser(UserDTO user)
  {
    return await _repository.AddUser(user: user);
  }

  public async Task<bool> DeleteUser(int id)
  {
    return await _repository.DeleteUser(id: id);
  }

  public async Task<List<User>> GetAll()
  {
    return await _repository.GetAll();
  }

  public async Task<User> GetById(int id)
  {
    return await _repository.GetById(id: id);
  }

  public async Task<User> UpdateUser(UserUpdateDTO user)
  {
    return await _repository.UpdateUser(user: user);
  }
}
