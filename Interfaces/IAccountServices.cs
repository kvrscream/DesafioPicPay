using estudoRepository.dtos;
using estudoRepository.Models;

namespace estudoRepository.Interfaces;

public interface IAccountServices
{
  Task<List<AccountModel>> GetAll();
  Task<AccountModel> GetById(int id);
  Task<AccountModel> Add(AccountDTO account);
  Task<AccountModel> Update(AccountDTO account);
  Task<bool> Delete(int id);
}