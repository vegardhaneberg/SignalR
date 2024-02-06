using Microsoft.AspNetCore.SignalR;
using SignalRBackend.Hubs;
using SignalRBackend.Models;

namespace SignalRBackend.Services;

public class NotificationService(IHubContext<NotificationHub> hubContext)
{
    public async Task PushNotification(NotificationRequest request)
    {
        await hubContext.Clients.All.SendAsync("ReceiveMessage", request.User, request.Message);
    }
}