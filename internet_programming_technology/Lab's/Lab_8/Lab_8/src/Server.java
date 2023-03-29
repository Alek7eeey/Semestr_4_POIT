import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Server {
    private static final int PORT = 8888;
    private static List<ClientHandler> clients = new ArrayList<>();
    private static int numberToGuess;
    private static boolean hasWinner = false;

    public static void main(String[] args) throws IOException {
        ServerSocket serverSocket = new ServerSocket(PORT);
        System.out.println("Server is running and waiting for clients...");

        while (clients.size() < 2) {
            Socket clientSocket = serverSocket.accept();
            ClientHandler clientHandler = new ClientHandler(clientSocket);
            clients.add(clientHandler);
            System.out.println("New client joined");
        }

        Random random = new Random();
        numberToGuess = random.nextInt(100) + 1;
        System.out.println("Number to guess is " + numberToGuess);

        while (!hasWinner) {
            for (ClientHandler client : clients) {
                client.sendMessageToServer("Guess a number between 1 and 100:");
            }
            int guess1 = clients.get(0).readNumber();
            int guess2 = clients.get(1).readNumber();
            System.out.println("Player 1 guessed: " + guess1);
            System.out.println("Player 2 guessed: " + guess2);

            if (guess1 == numberToGuess) {
                clients.get(0).sendMessageToServer("Congratulations, you won!");
                clients.get(1).sendMessageToServer("Sorry, you lost.");
                hasWinner = true;
            } else if (guess2 == numberToGuess) {
                clients.get(1).sendMessageToServer("Congratulations, you won!");
                clients.get(0).sendMessageToServer("Sorry, you lost.");
                hasWinner = true;
            } else {
                String message = "Number was " + (numberToGuess < guess1 ? "smaller" : "larger") + " than " + guess1;
                clients.get(0).sendMessageToServer(message);
                message = "Number was " + (numberToGuess < guess2 ? "smaller" : "larger") + " than " + guess2;
                clients.get(1).sendMessageToServer(message);
            }
        }

        for (ClientHandler client : clients) {
            client.close();
        }
        serverSocket.close();
    }
}