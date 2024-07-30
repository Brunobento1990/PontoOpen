using PontoOpen.Infrastructure.HttpService.Interfaces;
using PontoOpen.Infrastructure.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PontoOpen.Infrastructure.HttpService.Services;

public sealed class GoogleHttpService : IGoogleHttpService
{
    private const string _url = "/json?language=pt-BR&latlng={0},{1}location_type=ROOFTOP&result_type={2}&key={3}";
    private const string _premise = "premise";
    private const string _street_address = "street_address";
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ConfiguracaoApiGoogle _configuracaoApiGoogle;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReferenceHandler = ReferenceHandler.Preserve,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    public GoogleHttpService(
        IHttpClientFactory httpClientFactory,
        ConfiguracaoApiGoogle configuracaoApiGoogle)
    {
        _httpClientFactory = httpClientFactory;
        _configuracaoApiGoogle = configuracaoApiGoogle;
    }

    public async Task<ResponseApiLocalizacaoGoogle> GetAddressByLocationAsync(string latitude, string longitude)
    {
        var client = _httpClientFactory.CreateClient("ApiGoogle");
        var response = await client.GetAsync(string.Format(_url, latitude, longitude, _premise, _configuracaoApiGoogle.ApiKey));
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine(content);
            throw new Exception("Erro na api do google.");
        }

        var result = JsonSerializer.Deserialize<ResponseApiLocalizacaoGoogle>(content, _jsonSerializerOptions)
            ?? throw new Exception("Erro na desserelização do objeto de resposta da api do google!");

        if (result.Status.ToUpper() == "ZERO_RESULTS")
        {
            response = await client.GetAsync(string.Format(_url, latitude, longitude, _street_address, _configuracaoApiGoogle.ApiKey));
            content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(content);
                throw new Exception("Erro na api do google.");
            }

            return JsonSerializer.Deserialize<ResponseApiLocalizacaoGoogle>(content, _jsonSerializerOptions)
            ?? throw new Exception("Erro na desserelização do objeto de resposta da api do google!");
        }

        return result;
    }
}
