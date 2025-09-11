using System.Text;
using estudoRepository.Interfaces;
using estudoRepository.Models;
using Newtonsoft.Json;

namespace estudoRepository.Services;

public class NotifyService : INotifyService
{
  private readonly HttpClient _httpClient;

  public NotifyService(HttpClient httpClient)
  {
    _httpClient = httpClient;
    Console.WriteLine(_httpClient.BaseAddress);
  }

  public async Task<bool> Notify(string email)
  {
    string json = JsonConvert.SerializeObject(new
    {
      email
    });

    using StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage responseMessage = await _httpClient.PostAsync("/api/v1/notify", content);

    if (!responseMessage.IsSuccessStatusCode)
    {
      return false;
    }

    string responseContent = await responseMessage.Content.ReadAsStringAsync();
    NotifyModel notifyModel = JsonConvert.DeserializeObject<NotifyModel>(responseContent);

    return notifyModel.authorized;
  }
}