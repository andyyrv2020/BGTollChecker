using BGTollChecker.Models;

namespace BGTollChecker.Services
{
    public interface IBGTollService
    {
        Task<BGTollApiResponse> CheckVignetteAsync(
            string countryCode,
            string registrationNumber);
    }
}
