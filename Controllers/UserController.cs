using estudoRepository.dtos;
using estudoRepository.Interfaces;
using estudoRepository.Models;
using Microsoft.AspNetCore.Mvc;

namespace estudoRepository.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : Controller
  {
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
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
        return Ok(await _repository.GetById(id: id));
      } 
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserDTO user)
    {
      try
      {
        return Ok(await _repository.AddUser(user));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] UserDTO user)
    {
      try
      {
        return Ok(await _repository.UpdateUser(user));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById(int id)
    {
      try
      {
        return Ok(await _repository.DeleteUser(id: id));
      } 
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

  }
}