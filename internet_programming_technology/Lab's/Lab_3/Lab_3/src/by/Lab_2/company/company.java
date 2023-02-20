package by.Lab_2.company;

import java.util.Iterator;
import by.Lab_2.employee.Employee;
import  by.Lab_2.director.abstrDirector;
import by.Lab_2.exception.MyException;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.Collections;
import java.util.logging.Logger;

public class company {
    final Logger logger = Logger.getLogger("by.Lab_2.company");
    public String nameOfCompany;
    public ArrayList<Employee> arrayEmpl = new ArrayList<Employee>();

    public company(String nameOfCompany) {
        this.nameOfCompany = nameOfCompany;
        logger.info("Компания создана!");
    }

    @Override
    public String toString() {
        String text = "Компания: \n" + "Название: " + nameOfCompany + "\nСписок работников: \n";
        int i = 0;
        for (var a: arrayEmpl
             ) {
            text += a.toString();
        }
        return text;
    }

    public void fireAnEmloyee(String na)
    {
        boolean isTrue = false;
        Iterator<Employee> iterator = arrayEmpl.iterator();

        while (iterator.hasNext())
        {
            Employee employee = iterator.next();

            if (employee.getName().equals(na))
            {
                iterator.remove();
                isTrue = true;
            }
        }

        if(!isTrue)
        {
            System.out.println("Нет таких сотрудников!");
        }
        logger.info("Сотрудник уволен!");
    }

    public void HireAnEmployee(Employee newEmpl)
    {
        if (newEmpl != null)
        {
            arrayEmpl.add(newEmpl);
        }
        logger.info("Сотрудник добавлен!");
    }

    public class Director extends abstrDirector
    {
        public String nameOfDirector;

        public Director(String nameOfDirector) {
            this.nameOfDirector = nameOfDirector;
            logger.info("Директор создан!");
        }

        public void CountOfEmployee()
        {
            System.out.println(arrayEmpl.size());
        }

        public void sortBySalary() throws MyException
        {
            if (arrayEmpl.size() == 0)
            {
                throw new MyException("Ни одного сотрудника в компании нету!");
            }
            else {
                Collections.sort(arrayEmpl, Comparator.comparingInt(Employee::getSalary));
                System.out.println("Сотрудники, отсортированные в порядке возрастания: \n");
                for (var a : arrayEmpl
                ) {
                    System.out.println(a.toString());
                }
            }
            logger.info("Сотрудники отсортированы!");
        }

        public void GetEmployeeWithGivenEducation(boolean educ)
        {
            String ed;
            if (educ == true)
            {
                ed = "да";
            }

            else
            {
                ed = "нет";
            }

            for (var a: arrayEmpl
                 ) {
                if(a.higherEducation_ == ed)
                {
                    System.out.println(a.toString());
                }
            }
        }
    }
}
