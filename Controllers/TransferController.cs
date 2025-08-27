
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
  private readonly ITransferServices _services;
  public TransferController(ITransferServices services)
  {
    _services = services;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> MyTransfers(int id)
  {
    try
    {
      List<TransferModel> transfers = await _services.MyTransfers(Payee: id);
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
      TransferModel transferModel =
        await _services.CreateTransfer(transfer: transfer);
      return Ok(transferModel);
    }
    catch (Exception ex)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
    }

  }
}