
using BGTollChecker.Models;
using BGTollChecker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BGTollChecker.Controllers;

public class VignetteController : Controller
{
    private readonly IBGTollService _bgtollService;

    public VignetteController(IBGTollService bgtollService)
    {
        _bgtollService = bgtollService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new VignetteCheckViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(
     VignetteCheckViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        model.RegistrationNumber =
            model.RegistrationNumber.Trim().ToUpperInvariant();

        try
        {
            model.Result = await _bgtollService.CheckVignetteAsync(
                model.CountryCode,
                model.RegistrationNumber);

            if (!model.Result.Ok)
            {
                model.ErrorMessage =
                    "BGToll не успя да обработи проверката.";
            }
        }
        catch (HttpRequestException ex)
        {
            model.ErrorMessage = ex.Message;
        }
        catch (TaskCanceledException)
        {
            model.ErrorMessage =
                "Заявката към BGToll отне твърде много време.";
        }
        catch (System.Text.Json.JsonException)
        {
            model.ErrorMessage =
                "Отговорът от BGToll не е във валиден JSON формат.";
        }

        return View(model);
    }
}
