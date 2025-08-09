using estudoRepository.dtos.TransferDTOs;
using estudoRepository.Models;

namespace estudoRepository.Interfaces;

public interface ITransferRepository
{
  Task<TransferModel> SendTransfer(TransferDTO transfer);
  Task<List<TransferModel>> MyTransfers(int Payee);
}