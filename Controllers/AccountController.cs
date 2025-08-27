using estudoRepository.Interfaces;
using estudoRepository.Models;
using estudoRepository.dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using estudoRepository.Services;

namespace estudoRepository.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : Controller
  {
    private readonly IAccountServices _service;

    public AccountController(IAccountServices service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        return Ok(await _service.GetAll());
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
      try
      {
        return Ok(await _service.GetById(id: id));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Add(AccountDTO account)
    {
      try
      {
        return Ok(await _service.Add(account));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPatch]
    public async Task<IActionResult> Update(AccountDTO account)
    {
      try
      {
        return Ok(await _service.Update(account));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        return Ok(await _service.Delete(id));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

  }
}