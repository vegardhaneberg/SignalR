using System.ComponentModel.DataAnnotations;

namespace SignalRBackend.Models;

public class NotificationRequest
{
    [Required]
    public required string Message { get; set; }
    [Required]
    public required string User { get; set; }
}