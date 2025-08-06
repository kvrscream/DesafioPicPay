using System.ComponentModel.DataAnnotations.Schema;

namespace estudoRepository.Models
{
  public class AccountModel
  {
    public int Id { get; set; }
    public int userId { get; set; }
    public User? userModel { get; set; }
    public double balance { get; set; }
    public bool canNegativeBalance { get; set; }
  }
}