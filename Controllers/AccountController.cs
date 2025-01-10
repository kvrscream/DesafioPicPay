using estudoRepository.Interfaces;
using estudoRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace estudoRepository.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : Controller
  {
    private readonly IAccountRepository _repository;

    public AccountController(IAccountRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        return Ok(await _repository.GetAll());
      }
      catch(Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
      try
      {
        return Ok(_repository.GetById(id: id));
      }
      catch(Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Add(AccountModel account) 
    {
      try 
      {
        return Ok(await _repository.Add(account));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPatch]
    public async Task<IActionResult> Update(AccountModel account) 
    {
      try 
      {
        return Ok(await _repository.Update(account));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(AccountModel account) 
    {
      try 
      {
        return Ok(await _repository.Delete(account));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

  }
}