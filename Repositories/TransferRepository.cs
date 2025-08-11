using estudoRepository.Context;
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
    return await _context.Transfers.Where(w => w.Payee == Payee).ToListAsync();
  }

  public async Task<TransferModel> SendTransfer(TransferDTO transfer)
  {
    try
    {
      TransferModel transferModel = transfer.Adapt<TransferModel>();
      await _context.Transfers.AddAsync(transferModel);
      await _context.SaveChangesAsync();
      
      return transferModel;
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }
}