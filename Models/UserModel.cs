using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace estudoRepository.Models
{
  public class User : UserAbstract
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome não pode ser vazio.")]
    public string name { get; set; }

    [Required(ErrorMessage = "E-mail não pode ser vazio.")]
    public string email { get; set; }

    [Required(ErrorMessage = "Documento é obrigatório!")]
    public string document { get; set; }
  }
}