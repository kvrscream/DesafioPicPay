using estudoRepository.dtos;
using estudoRepository.dtos.TransferDTOs;
using estudoRepository.Models;
using estudoRepository.Repositories;
using Mapster;
using System.Linq;

namespace estudoRepository.Services;

public class TransferServices
{
  private readonly TransferRepository _transfer;
  private readonly AccountRepository _account;

  public async Task<TransferModel> CreateTransfer(TransferDTO transfer)
  {
    try
    {
      AccountModel payer = await _account.GetById(id: transfer.Payer); //Busca beneficiário pagador
      AccountModel payee = await _account.GetById(id: transfer.Payee); //Busca beneficiário destino
      if (payer.userModel!.userType.Equals("PJ"))
      {
        throw new Exception("Usuários do tipo Pessoa Jurídica não podem realizar transferências!");
      }

      if (payer.balance < transfer.Value && !payer.canNegativeBalance)
      {
        throw new Exception("Saldo insulficiente!");
      }

      payer.balance = payer.balance - transfer.Value;
      AccountDTO payerDTO = payer.Adapt<AccountDTO>();
      payee.balance = payee.balance + transfer.Value;
      AccountDTO payeeDTO = payee.Adapt<AccountDTO>();

      await Task.WhenAll(
        [
          _account.Update(payeeDTO),
          _account.Update(payerDTO)
        ]
      );

      return await _transfer.SendTransfer(transfer: transfer);

    }
    catch (Exception ex)
    {
      throw ex;
    }
  }
}