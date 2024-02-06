// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;

// Create a connection to the SignalR hub
var hubConnection = new HubConnectionBuilder()
    .WithUrl("https://localhost:7209/notifications")
    .WithAutomaticReconnect()
    .Build();

// Define how to handle incoming messages
hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
{
    Console.WriteLine($"Message from {user}: {message}");
});

// Start the connection and handle exceptions
try
{
    await hubConnection.StartAsync();
    Console.WriteLine("Connected to the hub. Press any key to exit.");
}
catch (Exception ex)
{
    Console.WriteLine($"Could not connect to the hub: {ex.Message}");
}

// Wait for the user to press a key before closing
Console.ReadKey();

// Optionally, stop the connection when the application is closing
await hubConnection.StopAsync();