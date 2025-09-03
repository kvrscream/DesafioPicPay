using estudoRepository.Interfaces;

namespace estudoRepository.Services;

public class AuthorizeService : IAuthorizeService
{
  private readonly IHttpClientFactory _httpClient;

  public AuthorizeService(IHttpClientFactory httpClient)
  {
    _httpClient = httpClient;
  }

  private readonly string URL = "https://util.devi.tools/api/v2/authorize";
  public async Task<bool> AuthorizeTransaction()
  {
    // Precisamos mocar o retorno aqui
    // Link da picpay sempre volta false
    using var response = await _httpClient.CreateClient().GetAsync(URL);
    string output = await response.Content.ReadAsStringAsync();
    Console.WriteLine(output);
    return true;
  }
}