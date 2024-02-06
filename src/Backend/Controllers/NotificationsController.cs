using Microsoft.AspNetCore.Mvc;
using SignalRBackend.Models;
using SignalRBackend.Services;

namespace SignalRBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationsController(NotificationService notificationService) : ControllerBase
{
    [HttpPost("Send")]
    public async Task<IActionResult> SendNotification([FromBody] NotificationRequest request)
    {
        if (!ModelState.IsValid) return BadRequest();
        await notificationService.PushNotification(request);
        return Ok();
    }
}
