using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRBackend.Models;
using SignalRBackend.Services;

namespace SignalRBackend.Pages;

public class CreateNotification(NotificationService notificationService, ILogger<CreateNotification> logger) : PageModel
{
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPost([FromForm] NotificationRequest notificationRequest)
    {
        if (!ModelState.IsValid) return Page();
        logger.LogInformation("{Message}", notificationRequest.Message);
        logger.LogInformation("{User}", notificationRequest.User);
        await notificationService.PushNotification(notificationRequest);

        return Page();
    }
}