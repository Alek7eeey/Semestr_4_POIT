package by.Lab_4.Main;

import by.Lab_4.Employee.Employee;
import by.Lab_4.Director.AbstrDirector;
import by.Lab_4.Exception.MyException;
import by.Lab_4.Company.company;
import by.Lab_4.xmlSeriaize.SaxParser;

import java.nio.file.Files;
import java.nio.file.Path;
import java.beans.XMLEncoder;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import org.xml.sax.helpers.DefaultHandler;
import org.xml.sax.*;
import java.io.*;
import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.Scanner;

import com.fasterxml.jackson.databind.ObjectMapper;

public class main {
    public static ArrayList<Employee> employees = new ArrayList<>();
    public static void main(String[] args) {
        try {
            /*---------WORK WITH XML-file---------*/
            SAXParserFactory factory = SAXParserFactory.newInstance();
            SAXParser parser = factory.newSAXParser();
            SaxParser saxp = new SaxParser();
            parser.parse(new File("Files\\xmlFile.xml"), saxp);

            for (Employee em: employees
                 ) {
                System.out.println(em.toString());
            }

            /*---------WORK WITH JSON-file---------*/
            Employee em1 = new Employee("Artem", true, "middle", 900);
            Employee em2 = new Employee("Andrey", false, "senior", 2500);
            Employee em3 = new Employee("Daria", true, "trainee", 200);
            Employee em4 = new Employee("Dmitry", false, "junior", 500);
            Employee em5 = new Employee("Aleksey", true, "senior", 4400);

            company myCompany = new company("Alek7ey");
            company.Director DirectorOfCompany = myCompany.new Director("Aleksandr");
            myCompany.HireAnEmployee(em1);
            myCompany.HireAnEmployee(em2);
            myCompany.HireAnEmployee(em3);
            myCompany.HireAnEmployee(em4);
            myCompany.HireAnEmployee(em5);

            System.out.println("\nSalary >20: ");
            DirectorOfCompany.FilterBySalary();

            ObjectMapper mapper = new ObjectMapper();
            String jsonBook = mapper.writeValueAsString(myCompany);
            var writer = new FileWriter("JSON_Serialize\\serialize.json");
            writer.write(jsonBook, 0, jsonBook.length());
            writer.close();

            company MyCompony_2 = null;
            Object obj;

                var file = new File("JSON_Serialize\\serialize.json");
                ObjectMapper ow = new ObjectMapper();
                obj = ow.readValue(Files.readString(Path.of(file.getPath())), company.class);

            if(obj instanceof company)
            {
                System.out.println("\nСериализация:\n");
                MyCompony_2 = (company) obj;
                System.out.println(MyCompony_2.toString());
            }
            else
            {
                System.out.println("Ошибка!");
            }



        }
        catch (Exception e) {
            e.printStackTrace();
        }
    }
}
