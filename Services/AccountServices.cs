using estudoRepository.Context;
using estudoRepository.dtos;
using estudoRepository.Interfaces;
using estudoRepository.Models;
using estudoRepository.Repositories;

namespace estudoRepository.Services;

public class AccountServices : IAccountServices
{

  private readonly IAccountRepository _repository;

  public AccountServices(IAccountRepository repository)
  {
    _repository = repository;
  }

  public async Task<AccountModel> Add(AccountDTO account)
  {
    return await _repository.Add(account: account);
  }

  public async Task<bool> Delete(int id)
  {
    return await _repository.Delete(id: id);
  }

  public async Task<List<AccountModel>> GetAll()
  {
    return await _repository.GetAll();
  }

  public async Task<AccountModel> GetById(int id)
  {
    return await _repository.GetById(id: id);
  }

  public async Task<AccountModel> Update(AccountDTO account)
  {
    return await _repository.Update(account: account);
  }
}