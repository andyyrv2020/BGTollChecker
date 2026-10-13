
using System.Net.Http;
using System.Text.Json;
using BGTollChecker.Models;

namespace BGTollChecker.Services;

public class BGTollService : IBGTollService
{
    private readonly HttpClient _httpClient;

    public BGTollService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BGTollApiResponse> CheckVignetteAsync(
        string countryCode,
        string registrationNumber)
    {
        string country = Uri.EscapeDataString(countryCode);
        string plate = Uri.EscapeDataString(registrationNumber);

        string endpoint =
            $"check/vignette/all/plate/{country}/{plate}";

        using var response = await _httpClient.GetAsync(endpoint);

        string content =
            await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"BGToll върна HTTP {(int)response.StatusCode}: {content}");
        }

        var result = JsonSerializer.Deserialize<BGTollApiResponse>(
            content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return result ?? throw new InvalidOperationException(
            "BGToll върна невалиден отговор.");
    }
}
