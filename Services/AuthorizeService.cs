using estudoRepository.Interfaces;

namespace estudoRepository.Services;

public class AuthorizeService : IAuthorizeService
{
  private readonly IHttpClientFactory _httpClient;

  public AuthorizeService(IHttpClientFactory httpClient)
  {
    _httpClient = httpClient;
  }

  private readonly string URL = "http ://qualquer-url .com"; //"https://util.devi.tools/api/v2/authorize";
  public async Task<bool> AuthorizeTransaction()
  {
    var client = _httpClient.CreateClient("AuthorizeClient");
    using var response = await client.GetAsync(URL);
    string output = await response.Content.ReadAsStringAsync();
    Console.WriteLine(output);
    return true;
  }
}