package ex1;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;

public class ConnectToInternetSource {
    public static void main(String [] args) {
        URL tut = null;
        String urlName = "https://diskstation.belstu.by:5001/";
        try{
            tut = new URL(urlName);
        } catch (MalformedURLException e){
            e.printStackTrace();
        }

        if (tut == null ) {
            throw new RuntimeException();
        }
        try (BufferedReader d = new BufferedReader(new InputStreamReader(tut.openStream()))){
            String line = "";
            while ((line = d.readLine()) != null){
                System.out.println(line);
            }
        } catch (IOException e)
        {
            e.printStackTrace();
        }

    }
}
