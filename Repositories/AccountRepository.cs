using estudoRepository.Models;
using estudoRepository.dtos;
using estudoRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using estudoRepository.Context;

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
        User user = await _context.Users.FirstOrDefaultAsync(f => f.Id == account.userModelId);
        AccountModel accountModel = new AccountModel();
        accountModel = account;
        accountModel.userModel = user;

        await _context.Accounts.AddAsync(accountModel);
        await _context.SaveChangesAsync();
        return accountModel;
    }

    public async Task<bool> Delete(AccountDTO account)
    {
        _context.Accounts.Remove(account);
        return true;
    }

    public async Task<List<AccountModel>> GetAll()
    {
      return await _context.Accounts.ToListAsync();
    }

    public async Task<AccountModel> GetById(int id)
    {
        return await _context.Accounts.
          Include(u => u.userModel).FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<AccountModel> Update(int id)
    {
        AccountModel actualAccount = await this.GetById(id: id);
        if (actualAccount != null)
        {
          actualAccount.balance = account.balance;
          actualAccount.canNegativeBalance = account.canNegativeBalance;
          await _context.SaveChangesAsync();
          return actualAccount;
        }
        return null;
    }
  }
}