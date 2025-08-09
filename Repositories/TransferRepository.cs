using estudoRepository.Context;
using estudoRepository.dtos.TransferDTOs;
using estudoRepository.Interfaces;
using estudoRepository.Models;

namespace estudoRepository.Repositories;

public class TransferRepository : ITransferRepository
{
  private readonly ApplicationDbContext _context;
  public TransferRepository(ApplicationDbContext context)
  {
    _context = context;
  }
  
  public Task<List<TransferModel>> MyTransfers(int Payee)
  {
    throw new NotImplementedException();
  }

  public Task<TransferModel> SendTransfer(TransferDTO transfer)
  {
    throw new NotImplementedException();
  }
}