using System.ComponentModel.DataAnnotations;

namespace estudoRepository.Models
{
  public abstract class UserAbstract
  {
    [Required(ErrorMessage = "Documento é obrigatório!")]
    public string document { get; set; }

    [MaxLength(2)]
    public string userType { get; set; } 
  }
}