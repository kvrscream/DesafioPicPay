using estudoRepository.dtos;
using estudoRepository.dtos.UserDTOs;
using estudoRepository.Interfaces;
using estudoRepository.Models;
using estudoRepository.Services;
using Microsoft.AspNetCore.Mvc;

namespace estudoRepository.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : Controller
  {
    private readonly IUserServices _services;

    public UserController(IUserServices services)
    {
      _services = services;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        return Ok(await _services.GetAll());
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
        return Ok(await _services.GetById(id: id));
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
        return Ok(await _services.AddUser(user));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] UserUpdateDTO user)
    {
      try
      {
        return Ok(await _services.UpdateUser(user));
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
        return Ok(await _services.DeleteUser(id: id));
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

  }
}