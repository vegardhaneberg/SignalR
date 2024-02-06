## SignalR Demo project

The project consists of two .NET applications and a react application. The first .NET app is a backend that exposes an endpoint to push notifications. The second .NET app is a console app that listens to notifications and displays them in the terminal. The react app also subscribes to the notifications and displays them in the browser.

### Getting started

**Run the backend**

Navigate to `./src/Backend` and run `ASPNETCORE_ENVIRONMENT=Development dotnet watch --launch-profile https`

**Run the receiver console application**

In a new terminal, navigate to `./src/Receiver` and run `dotnet run`

Now you can make POST requests to https://localhost:7209/Notifications/Send with the following data

```json
{
  "User": "Vegard Haneberg",
  "Message": "Hello World!"
}
```

The Receiver terminal should display the notification.

**Run the receiver react app**

In a new terminal, navigate to `./src/signalr-receiver-react` and run `npm install` and `npm run dev`. The app should run on http://localhost:5173 to not cause CORS problems when connecting to the SignalR Hub.
