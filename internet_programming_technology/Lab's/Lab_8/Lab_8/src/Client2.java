import java.io.*;
import java.net.Socket;

public class Client2 {
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
                String serverMessage = reader.readLine();
                System.out.println(serverMessage);

                if (serverMessage.equals("Введите цифру от 1 до 100") || serverMessage.equals("Это слишком мало!") || serverMessage.equals("Это слишком много!")) {
                    String clientMessage = consoleReader.readLine();
                    writer.write(clientMessage);
                    writer.newLine();
                    writer.flush();
                }

                else
                {
                    break;
                }
            }

        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}