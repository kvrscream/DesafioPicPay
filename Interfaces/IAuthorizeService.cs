namespace estudoRepository.Interfaces;

public interface IAuthorizeService
{
  Task<bool> AuthorizeTransaction();
}