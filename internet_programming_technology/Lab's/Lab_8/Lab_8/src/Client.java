import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

public class Client {
    public static void main(String[] args) throws IOException {
        Socket socket = new Socket("127.0.0.1",8088);
        System.out.println("Connected to server");

        BufferedReader clientInput = new BufferedReader(new InputStreamReader(System.in));
        ClientHandler serverHandler = new ClientHandler(socket);

        while (!serverHandler.isPlaying()) {
            System.out.println(serverHandler.getMessageFromServer());
        }

        while (serverHandler.isPlaying()) {
            String userInput = clientInput.readLine();
            serverHandler.sendMessageToServer(userInput);

            System.out.println(serverHandler.getMessageFromServer());
        }

        socket.close();
    }
}

class ClientHandler {
    private Socket socket;
    private BufferedReader inputFromServer;
    private PrintWriter outputToServer;
    private boolean playing;

    public ClientHandler(Socket socket) throws IOException {
        this.socket = socket;
        inputFromServer = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        outputToServer = new PrintWriter(socket.getOutputStream(), true);
    }

    public void sendMessageToServer(String message) {
        outputToServer.println(message);
    }

    public String getMessageFromServer() throws IOException {
        String message = inputFromServer.readLine();
        if (message != null) {
            if (message.equals("Guess a number between 1 and 100:")) {
                playing = true;
            } else if (message.startsWith("Congratulations") || message.startsWith("Sorry")) {
                playing = false;
            }
        }
        return message;
    }

    public boolean isPlaying() {
        return playing;
    }
    public void close() throws IOException {
        socket.close();
    }
    public int readNumber() throws IOException {
        return Integer.parseInt(inputFromServer.readLine());
    }
}