using estudoRepository.Context;
using estudoRepository.dtos;
using estudoRepository.dtos.TransferDTOs;
using estudoRepository.Interfaces;
using estudoRepository.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace estudoRepository.Repositories;

public class TransferRepository : ITransferRepository
{
  private readonly ApplicationDbContext _context;
  public TransferRepository(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<List<TransferModel>> MyTransfers(int Payee)
  {
    return await _context.Transfers
      .Include(i => i.PayeeUser)
      .Where(w => w.PayeeUser.userId == Payee).ToListAsync();
  }

  public async Task<TransferModel> SendTransfer(TransferDTO transfer, AccountModel payer, AccountModel payee)
  {
    using var transaction = _context.Database.BeginTransaction();
    try
    {
      payer.balance = payer.balance - transfer.Value;
      payee.balance = payee.balance + transfer.Value;

      TransferModel transferModel = transfer.Adapt<TransferModel>();
      await _context.Transfers.AddAsync(transferModel);
      await _context.SaveChangesAsync();

      transaction.Commit();
      return transferModel;
    }
    catch (Exception ex)
    {
      transaction.Rollback();
      throw ex;
    }
  }
}