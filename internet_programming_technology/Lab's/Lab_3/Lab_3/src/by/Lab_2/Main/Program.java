package by.Lab_2.Main;

import by.Lab_2.company.company;
import by.Lab_2.employee.Employee;
import by.Lab_2.exception.MyException;
import java.util.logging.*;

import static java.util.logging.Level.*;

public class Program {
    public static void main(String[] args)
    {
        final Logger logger = Logger.getLogger("by.Lab_2.Main");
        logger.setLevel(Level.INFO);

        try {
            logger.info("Программа main начала выполнение");

            Employee em1 = new Employee("Artem", true, Employee.position.middle, 900);
            Employee em2 = new Employee("Andrey", false, Employee.position.senior, 2500);
            Employee em3 = new Employee("Daria", true, Employee.position.trainee, 200);
            Employee em4 = new Employee("Dmitry", false, Employee.position.junior, 500);
            Employee em5 = new Employee("Aleksey", true, Employee.position.senior, 4400);

            company myCompany = new company("Alek7ey");
            company.Director DirectorOfCompany = myCompany.new Director("Aleksandr");
            myCompany.HireAnEmployee(em1);
            myCompany.HireAnEmployee(em2);
            myCompany.HireAnEmployee(em3);
            myCompany.HireAnEmployee(em4);
            myCompany.HireAnEmployee(em5);

            System.out.println(myCompany.toString());
            System.out.println("Количество сотрудников в компании: "); DirectorOfCompany.CountOfEmployee();
            System.out.println("Сотрудники с высшим образованием: \n");
            DirectorOfCompany.GetEmployeeWithGivenEducation(true);
            DirectorOfCompany.sortBySalary();

            logger.info("Программа main завершена");
        }
        catch (MyException ex)
        {
            System.out.println("Ошибка: " + ex.getMessage());
        }
    }

}
