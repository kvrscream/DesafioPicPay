
using estudoRepository.dtos.TransferDTOs;
using estudoRepository.Interfaces;
using estudoRepository.Models;
using estudoRepository.Repositories;
using estudoRepository.Services;
using Microsoft.AspNetCore.Mvc;

namespace estudoRepository.Controllers;

[Route("api/transfer")]
[ApiController]
public class TransferController : Controller
{
  private readonly TransferRepository _transfer;
  private readonly AccountRepository _account;
  public TransferController(TransferRepository transfer, AccountRepository account)
  {
    _transfer = transfer;
    _account = account;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> MyTransfers(int id)
  {
    try
    {
      List<TransferModel> transfers = await _transfer.MyTransfers(Payee: id);
      return Ok(transfers);
    }
    catch (Exception ex)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
    }
  }

  [HttpPost("create")]
  public async Task<IActionResult> SendTransfer([FromBody] TransferDTO transfer)
  {
    try
    {
      TransferServices services = new TransferServices(account: _account, transfer: _transfer);
      TransferModel transferModel = 
        await services.CreateTransfer(transfer: transfer);
      return Ok(transferModel);
    }
    catch (Exception ex)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
    }

  }
}