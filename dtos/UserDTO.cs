using System.ComponentModel.DataAnnotations;

namespace estudoRepository.dtos
{
  public class UserDTO
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome não pode ser vazio")]
    public string name { get; set; }

    [Required(ErrorMessage = "E-mail não pode ser vazio")]
    public string email { get; set; }
    public string document { get; set; }
    public string Password { get; set; }
  }
}