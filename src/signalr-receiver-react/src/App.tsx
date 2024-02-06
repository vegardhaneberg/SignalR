import { useEffect, useState } from "react";
import "./App.css";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";

interface Message {
  user: string;
  message: string;
}

function App() {
  const [messages, setMessages] = useState<Message[]>([]);

  useEffect(() => {
    const connection: HubConnection = new HubConnectionBuilder()
      .withUrl("https://localhost:7209/notifications")
      .withAutomaticReconnect()
      .build();

    connection
      .start()
      .then(() => {
        console.log("Connected to the hub");
      })
      .catch((err: string) => {
        console.error("Error connecting to the hub:", err);
      });

    connection.on("ReceiveMessage", (user: string, message: string) => {
      console.log("lol");
      const newMessage: Message = { user, message };
      setMessages((messages) => [...messages, newMessage]);
    });
    return () => {
      connection.stop();
    };
  }, []);

  return (
    <>
      <h2>Notifications</h2>
      <ul>
        {messages.map((msg, index) => {
          return (
            <li key={index}>
              {msg.user}: {msg.message}
            </li>
          );
        })}
      </ul>
    </>
  );
}

export default App;
