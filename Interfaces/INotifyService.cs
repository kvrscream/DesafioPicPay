namespace estudoRepository.Interfaces;

public interface INotifyService
{
  Task<bool> Notify(string email);
}