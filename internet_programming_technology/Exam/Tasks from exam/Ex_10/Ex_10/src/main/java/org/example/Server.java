package org.example;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class Server {
    static List<Socket> clients = new ArrayList<>();
    static List<Integer> clientsMoney = new ArrayList<>();
    static List<String> nameClients = new ArrayList<>();
    public static void main(String []args) throws IOException {
        try(ServerSocket serverSocket = new ServerSocket(8081)) {
            System.out.println("Server started...");

            while (true){

                try{
                    Socket socket = serverSocket.accept();
                    clients.add(socket);
                    clientsMoney.add(0);
                    new Thread(new Runnable() {
                        @Override
                        public void run() {
                            try (BufferedReader reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                                 BufferedWriter writer = new BufferedWriter(new OutputStreamWriter((socket.getOutputStream())));
                            ) {
                                String request = reader.readLine();
                                String response = String.format("Client '" + request + "' connected! ");
                                nameClients.add(request);

                                int Index = clients.indexOf(socket);
                                int money = clientsMoney.get(Index);
                                System.out.println(response);

                                while (true)
                                {

                                    request = reader.readLine();

                                    String regex = "^/donate\\s+\\d+$";

                                    if (request.matches(regex)) {

                                        String digits = "";
                                        for (int i = 0; i < request.length(); i++) {
                                            if (Character.isDigit(request.charAt(i))) {
                                                digits += request.charAt(i);
                                            }
                                        }

                                        int amount = Integer.parseInt(digits);
                                        int money2 = clientsMoney.get(Index) + amount;
                                        clientsMoney.set(Index, money2); // добавление в коллекцию
                                        writer.write("Сумма добавлена! " + "Ваш счёт: " + money2);
                                        writer.newLine();
                                        writer.flush();
                                    }

                                    else if(request.equals("/get"))
                                    {
                                        clientsMoney.set(Index, 0);
                                        writer.write("Счёт удалён!\n");
                                        writer.newLine();
                                        writer.flush();
                                    }

                                    else if(request.equals("/end"))
                                    {
                                        String nameClientThis = nameClients.get(clients.indexOf(socket));
                                        System.out.println("Клиент '" + nameClientThis + "' отключился!");
                                        break;
                                    }

                                    else
                                    {
                                        writer.write("null");
                                        writer.newLine();
                                        writer.flush();
                                    }

                                    String nameClientThis = nameClients.get(clients.indexOf(socket));
                                    System.out.println("Клиент '" + nameClientThis + "' : " + request);

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
