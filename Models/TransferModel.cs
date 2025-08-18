using System.ComponentModel.DataAnnotations.Schema;

namespace estudoRepository.Models;

public class TransferModel
{

  public TransferModel()
  {
    Created = DateTime.Now;
  }
  public int Id { get; set; }
  public double Value { get; set; }
  public int Payer { get; set; }
  [ForeignKey("Payer")]
  public AccountModel PayerUser { get; set; }
  public int Payee { get; set; }
  [ForeignKey("Payee")]
  public AccountModel PayeeUser { get; set; }
  public DateTime Created { get; set; }
}