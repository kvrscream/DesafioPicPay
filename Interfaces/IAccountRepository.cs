using estudoRepository.Models;
using estudoRepository.dtos;

namespace estudoRepository.Interfaces
{
  public interface IAccountRepository
  {
    Task<List<AccountModel>> GetAll();
    Task<AccountModel> GetById(int id);
    Task<AccountModel> Add(AccountDTO account);
    Task<AccountModel> Update(AccountDTO account);
    Task<bool> Delete(int id);
  }
}