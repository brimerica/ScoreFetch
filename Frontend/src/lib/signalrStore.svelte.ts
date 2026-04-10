import * as signalR from '@microsoft/signalr';
import { browser } from '$app/environment';

class SignalRManager {
    // Define reactive properties using runes
    data = $state<string>("Connecting...");
    isConnected = $state<boolean>(false);
    
    private connection: signalR.HubConnection | null = null;

    start() {
        // Guard: SignalR needs the browser's WebSocket API
        if (!browser || this.connection) return;

        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("http://localhost:5266/dataHub") // Ensure this matches your .NET port
            .withAutomaticReconnect()
            .build();

        // Listen for the 'ReceiveData' call from your C# BackgroundService
        this.connection.on("ReceiveData", (newData: string) => {
            this.data = JSON.parse(newData);
        });

        this.connection.onreconnecting(() => this.isConnected = false);
        this.connection.onreconnected(() => this.isConnected = true);

        this.connection.start()
            .then(() => {
                this.isConnected = true;
                console.log("SignalR Connected");
            })
            .catch(err => console.error("SignalR Connection Error: ", err));
    }
}

// Export a single instance to be used across the app
export const signalrManager = new SignalRManager();