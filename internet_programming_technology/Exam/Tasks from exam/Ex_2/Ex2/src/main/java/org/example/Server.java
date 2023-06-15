package org.example;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.*;

public class Server {
    public static void main(String[] args)
    {
        ArrayList<Socket> clients = new ArrayList<>();
        Map<String, String> topics = new HashMap<>();
        ArrayList<String> nameClients = new ArrayList<>();
        topics.put("Car", "Car dsfsdfsdfsdfsdfsdfsdfsf");
        topics.put("Car", "2Car dfghfhddtttttttttttydfg543435433dsfsdfsdfsdfsdfsdfsdfsf");
        topics.put("Fishing", "Fishingfdsfsdfsd sdfs sdfsdfddfghfhddtttttttttttydfg543435433dsfsdfsdfsdfsdfsdfsdfsf");
        topics.put("OOP", "OOpfdsfsdfsd sdfs sdfsdfddfghfhddttttttOOP OOPtttttydfg543435433dsfsdfsdfsdfsdfsdfsdfsf");
        topics.put("JS", "JSfdsfsdfsd sJSdfs sdfsdfddfghfhddttttttJS JStttttydfg543435433dsJSJSJSJSfsdfsdfsdfsdfsdfsdfsf");
        topics.put("JS", "JS22222fdsfsdfsd sJSdfs sdfsdfddfghfhddttttttJS JStttttydfg543435433dsJSJSJSJSfsdfsdfsdfsdfsdfsdfsf");

        try(ServerSocket serverSocket = new ServerSocket(8081)) {
            System.out.println("Server started...");

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
                                String request = reader.readLine();
                                String response = String.format("Client '" + request + "' connected! ");
                                nameClients.add(request);
                                System.out.println(response);

                                while (true)
                                {
                                    request = reader.readLine();
                                    String str = "";

                                    if (request.equals("/topic")) {
                                        for (var a:topics.keySet()
                                             ) {
                                            str += a.toString() + "/";
                                        }
                                        writer.write(str);
                                        writer.newLine();
                                        writer.flush();

                                       request = reader.readLine();
                                        String s= "";
                                        for(Map.Entry<String, String> entry : topics.entrySet())
                                        {
                                            String key = entry.getKey();
                                            String value = entry.getValue();
                                            if(request.equals(key))
                                            {
                                                s+=value + "/n";
                                            }
                                        }
                                           try {
                                               writer.write(s);
                                               writer.newLine();
                                           } catch (IOException e) {
                                               throw new RuntimeException(e);
                                           }


                                        writer.flush();

                                    }
                                    else {
                                        if(request.equals("end"))
                                        {
                                            String nameClientThis = nameClients.get(clients.indexOf(socket));
                                            System.out.println("Клиент '" + nameClientThis + " отключился!");
                                            break;
                                        }
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
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    }
