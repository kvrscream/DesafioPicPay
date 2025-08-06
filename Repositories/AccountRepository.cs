using estudoRepository.Models;
using estudoRepository.dtos;
using estudoRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using estudoRepository.Context;
using Mapster;

namespace estudoRepository.Repositories
{
  public class AccountRepository : IAccountRepository
  {
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<AccountModel> Add(AccountDTO account)
    {
        AccountModel accountModel = account.Adapt<AccountModel>();

        await _context.Accounts.AddAsync(accountModel);
        await _context.SaveChangesAsync();
        return accountModel;
    }

    public async Task<bool> Delete(int id)
    {
        AccountModel account = await this.GetById(id: id);
        _context.Accounts.Remove(account);
        return true;
    }

    public async Task<List<AccountModel>> GetAll()
    {
      return await _context.Accounts.
        Include(u => u.userModel).ToListAsync();
    }

    public async Task<AccountModel> GetById(int id)
    {
        return await _context.Accounts.
          Include(u => u.userModel).FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<AccountModel> Update(AccountDTO account)
    {
        AccountModel actualAccount = await this.GetById(id: account.Id);
        if (actualAccount != null)
        {
          actualAccount = account.Adapt<AccountModel>();
          await _context.SaveChangesAsync();
          return actualAccount;
        }
        return null;
    }
  }
}