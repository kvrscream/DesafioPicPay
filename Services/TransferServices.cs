using estudoRepository.dtos;
using estudoRepository.dtos.TransferDTOs;
using estudoRepository.Interfaces;
using estudoRepository.Models;
using estudoRepository.Repositories;
using Mapster;
using System.Linq;

namespace estudoRepository.Services;

public class TransferServices : ITransferServices
{
  private readonly ITransferRepository _transfer;
  private readonly IAccountRepository _account;

  private readonly IAuthorizeService _authorize;
  private readonly INotifyService _notifyService;

  public TransferServices(ITransferRepository transfer, IAccountRepository account,
    IAuthorizeService authorize, INotifyService notifyService)
  {
    _transfer = transfer;
    _account = account;
    _authorize = authorize;
    _notifyService = notifyService;
  }

  public async Task<TransferModel> CreateTransfer(TransferDTO transfer)
  {
    try
    {
      bool isAuthorized = await _authorize.AuthorizeTransaction();

      if (!isAuthorized)
      {
        throw new Exception("Usuário não autorizado!");
      }

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
      await _notifyService.Notify(email: payee.userModel.email);
      return await _transfer.SendTransfer(transfer: transfer, payee: payee, payer: payer);
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  public async Task<List<TransferModel>> MyTransfers(int Payee)
  {
    return await _transfer.MyTransfers(Payee: Payee);
  }

}