import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Server2 {
    public static boolean hasWinner = true;
    static List<Socket> clients = new ArrayList<>();
    static List<String> nameClients = new ArrayList<>();
    static Random random = new Random();
    static int numberToGuess = random.nextInt(100) + 1;

    public static void main(String []args) throws IOException {
        try(ServerSocket serverSocket = new ServerSocket(8081)) {
            System.out.println("Server started...");
            System.out.println("Цифра: " + numberToGuess);

            while (true){

                try{
                    Socket socket = serverSocket.accept();
                    clients.add(socket);
                    new Thread(new Runnable() {
                        @Override
                        public void run() {
                            try (BufferedReader reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                                 BufferedWriter writer = new BufferedWriter(new OutputStreamWriter((socket.getOutputStream())));
                            ) {
                                hasWinner = true;
                                String request = reader.readLine();
                                String response = String.format("Client '" + request + "' connected! ");
                                nameClients.add(request);
                                System.out.println(response);

                                while (hasWinner)
                                {
                                    writer.write("Введите цифру от 1 до 100");
                                    writer.newLine();
                                    writer.flush();
                                    request = reader.readLine();

                                        if (Integer.parseInt(request) == numberToGuess) {
                                            writer.write("Вы победили!\n");
                                            writer.newLine();
                                            writer.flush();

                                            //определение победителя
                                            int winnerIndex = clients.indexOf(socket);
                                            String name = nameClients.get(winnerIndex);
                                            System.out.println("Client '" + name + "' победил!");
                                            System.out.println("Client '" + name + "' disconnected!");

                                            clients.remove(winnerIndex);
                                            nameClients.remove(winnerIndex);

                                            if (clients.size() == 0) {
                                                numberToGuess = random.nextInt(100) + 1;
                                                System.out.println("\nНовая цифра: " + numberToGuess);
                                            }

                                            break;
                                        }

                                    if (Integer.parseInt(request) == -1) {
                                            //определение победителя
                                            int winnerIndex = clients.indexOf(socket);
                                            String name = nameClients.get(winnerIndex);
                                            System.out.println("Client '" + name + "' сдался!");
                                            System.out.println("Client '" + name + "' disconnected!");

                                            //определения победителя
                                            writer.write("Вы сдались!");
                                            writer.newLine();
                                            writer.flush();

                                            clients.remove(winnerIndex);
                                            nameClients.remove(winnerIndex);

                                            if (clients.size() == 0) {
                                                numberToGuess = random.nextInt(100) + 1;
                                                System.out.println("\nНовая цифра: " + numberToGuess);
                                            }

                                            break;
                                        }

                                        String nameClientThis = nameClients.get(clients.indexOf(socket));
                                        System.out.println("Клиент '" + nameClientThis + "' : " + request);

                                    /*if (Integer.parseInt(request) < numberToGuess) {
                                        writer.write("Это слишком мало!");
                                        writer.newLine();
                                        writer.flush();
                                    }

                                    if (Integer.parseInt(request) > numberToGuess) {
                                        writer.write("Это слишком много!");
                                        writer.newLine();
                                        writer.flush();
                                    }*/

                                    }

                            } catch (IOException e) {
                                e.printStackTrace();
                            }
                        }
                    }).start();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
}
