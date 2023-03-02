package by.Lab_4.Company;

import java.util.Iterator;
import by.Lab_4.Employee.Employee;
import  by.Lab_4.Director.AbstrDirector;
import by.Lab_4.Exception.MyException;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.Collections;
import java.util.logging.Logger;
import java.util.stream.Collectors;

public class company {
    final Logger logger = Logger.getLogger("by.Lab_2.company");
    public String nameOfCompany;
    public ArrayList<Employee> arrayEmpl = new ArrayList<Employee>();

    public company(String nameOfCompany) {
        this.nameOfCompany = nameOfCompany;
    }

    public company(){}

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
    }

    public void HireAnEmployee(Employee newEmpl)
    {
        if (newEmpl != null)
        {
            arrayEmpl.add(newEmpl);
        }
    }

    public class Director extends AbstrDirector
    {
        public String nameOfDirector;

        public Director(String nameOfDirector) {
            this.nameOfDirector = nameOfDirector;
        }
        public void FilterBySalary()
        {
            arrayEmpl.stream().filter(c->c.getSalary()>20).collect(Collectors.toList()).forEach(el-> System.out.println(el.toString()));
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
        }


    }
}
