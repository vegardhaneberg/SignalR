using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRBackend.Hubs;

namespace SignalRBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationsController(IHubContext<NotificationHub> hubContext) : ControllerBase
{
    [HttpPost("Send")]
    public async Task<IActionResult> SendNotification([FromBody] NotificationRequest request)
    {
        await hubContext.Clients.All.SendAsync("ReceiveMessage", request.User, request.Message);
        return Ok();
    }
}

public class NotificationRequest
{
    [Required]
    public required string Message { get; set; }
    [Required]
    public required string User { get; set; }
}