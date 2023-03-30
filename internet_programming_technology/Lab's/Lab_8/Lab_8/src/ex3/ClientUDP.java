package ex3;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;

public class ClientUDP {
    public static void main(String []args){
        try {
            // создаём сокет
            DatagramSocket aSocket = new DatagramSocket();
            // задаём строку для передачи
            String str = "Hello";
            // и преобразуем её в поток байт
            byte [] message = str.getBytes();
            // получаем IP-адрес компьютера в формате Java
            InetAddress aHost = InetAddress.getByName("localhost");
            // задаём порт
            int sPort = 1212;
            // создаём дейтаграмму, длина которой определяется длиной // сообщения
            DatagramPacket request = new  DatagramPacket(message, message.length, aHost, sPort);
            // передаём серверу
            aSocket.send(request);
            // определяем буфер под ответ сервера
            byte [] buffer = new byte[1000];
            // создаём дейтаграмму под ответ сервера
            DatagramPacket reply = new DatagramPacket(buffer, buffer.length);
            // принимаем ответ
            aSocket.receive(reply);
            // выводим ответ на консоль
            System.out.println("Reply: " + new String(reply.getData(), 0, reply.getLength()));
            // закрываем сокет
            aSocket.close();
        }
        catch (SocketException e) {
            // если не получилось создать сокет
            System.out.println("Socket: " + e.getMessage());
        }
        catch (IOException e) {
            // ошибка при приеме
            System.out.println("IO: " + e.getMessage());
        }
    }

}
