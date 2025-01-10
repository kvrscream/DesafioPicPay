using estudoRepository.Models;

namespace estudoRepository.Interfaces
{
  public interface IAccountRepository
  {
    Task<List<AccountModel>> GetAll();
    Task<AccountModel> GetById(int id);
    Task<AccountModel> Add(AccountModel account);
    Task<AccountModel> Update(AccountModel account);
    Task<bool> Delete(AccountModel account);
  }
}