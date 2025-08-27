using estudoRepository.dtos.TransferDTOs;
using estudoRepository.Models;

namespace estudoRepository.Interfaces;

public interface ITransferServices
{
  Task<TransferModel> CreateTransfer(TransferDTO transfer); //SendTransfer(TransferDTO transfer, AccountModel payer, AccountModel payee);
  Task<List<TransferModel>> MyTransfers(int Payee);
}