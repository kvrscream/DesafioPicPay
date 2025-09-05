using System.Net.Http;
using estudoRepository.Interfaces;
using estudoRepository.Models;
using Newtonsoft.Json;

namespace estudoRepository.Services;

public class AuthorizeService : IAuthorizeService
{
  private readonly HttpClient _httpClient;

  public AuthorizeService(HttpClient httpClient)
  {
    _httpClient = httpClient;
    Console.WriteLine($"BaseAddress: {_httpClient}");
  }

  public async Task<bool> AuthorizeTransaction()
  {
    using var response = await _httpClient.GetAsync("/api/v2/authorize");
    string output = await response.Content.ReadAsStringAsync();
    AuthorizeModel authorize = JsonConvert.DeserializeObject<AuthorizeModel>(output);
    return authorize.authorized;
  }
}