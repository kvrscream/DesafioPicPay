namespace estudoRepository.dtos.TransferDTOs;

public class TransferDTO
{
  public int Id { get; set; }
  public double Value { get; set; }
  public int Payer { get; set; }
  public int Payee { get; set; }
  public DateTime Created { get; set; }
}