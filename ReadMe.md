## SignalR Demo project
The project consists of two .NET applications. One backend that exposes an endpoint to push notifications and a Console app that listens to notifications.
### Getting started
Run the backend: 

Navigate to `./src/Backend` and run `ASPNETCORE_ENVIRONMENT=Development dotnet watch --launch-profile https`

Run the receiver console application:

In a new terminal, navigate to `./src/Receiver` and run `dotnet run`

Now you can make POST requests to https://localhost:7209/Notifications/Send with the following data
```json
{
  "User": "Vegard Haneberg",
  "Message": "Hello World!"
}
```
The Receiver terminal should display the notification.