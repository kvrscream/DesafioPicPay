namespace estudoRepository.Models;

public class TransferModel
{
  public int Id { get; set; }
  public double Value { get; set; }
  public int Payer { get; set; }
  public User PayerUser { get; set; }
  public int Payee { get; set; }
  public User PayeeUser { get; set; }
  public DateTime Created { get; set; }
}