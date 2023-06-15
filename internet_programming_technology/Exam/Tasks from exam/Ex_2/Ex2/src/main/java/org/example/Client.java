package org.example;

import java.io.*;
import java.net.Socket;

public class Client {
    public static void main(String[] args) throws IOException {
        String host = "localhost";
        int port = 8081;

        try (Socket socket = new Socket(host, port);
             BufferedReader reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));
             BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
             BufferedReader consoleReader = new BufferedReader(new InputStreamReader(System.in))) {

            System.out.print("Введите ваше имя: ");
            String name = consoleReader.readLine();
            writer.write(name);
            writer.newLine();
            writer.flush();

            while (true) {
                System.out.print("Введите команду: ");
                name = consoleReader.readLine();
                writer.write(name);
                writer.newLine();
                writer.flush();
                if(name.equals("end"))
                {
                    System.out.print("Пока!\n");
                    break;
                }

                String serverMessage = reader.readLine();


                if(serverMessage.equals("null"))
                {
                    System.out.print("Сообщение от сервера: нет\n");
                }
                else {
                    System.out.print("Сообщение от сервера: \n");
                    System.out.println(serverMessage);
                }
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
