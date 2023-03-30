package ex3;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.SocketException;

public class ServerUDP {
    public static void main(String []args) throws SocketException {
        DatagramSocket socket = null;

        try{
            socket = new DatagramSocket(1212);
            byte [] buffer = new byte[1000];
            while(true){
                DatagramPacket request = new DatagramPacket(buffer, buffer.length);
                // принимаем пакет клиента
                socket.receive(request);
                byte [] b = "hello".getBytes();

                // создаём ответную дейтаграмму
                DatagramPacket reply = new DatagramPacket(b,
                        b.length, request.getAddress(), request.getPort());
                // отправляем ответ клиенту
                socket.send(reply);
            }
        } catch (SocketException e) {
            throw new RuntimeException(e);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }


    }
}
