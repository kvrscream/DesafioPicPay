using estudoRepository.dtos.TransferDTOs;
using estudoRepository.Models;

namespace estudoRepository.Interfaces;

public interface ITransferRepository
{
  Task<TransferModel> SendTransfer(TransferDTO transfer, AccountModel payer, AccountModel payee);
  Task<List<TransferModel>> MyTransfers(int Payee);
}