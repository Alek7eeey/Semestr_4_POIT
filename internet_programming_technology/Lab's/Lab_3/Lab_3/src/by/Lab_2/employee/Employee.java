package by.Lab_2.employee;

import by.Lab_2.exception.MyException;

import java.util.logging.Level;
import java.util.logging.Logger;

public class Employee implements IEmployee{
    final Logger logger = Logger.getLogger("by.Lab_2.employee");
    public String name;
    Boolean higherEducation;
    public String higherEducation_;
    public position Posit;

    public int getSalary() {
        return salary;
    }

    public void setSalary(int salary) throws MyException {
        if (salary < 0)
        {
            throw new MyException("Зарплата не может быть отрицательная");
        }
        this.salary = salary;
    }

    public int salary;

    public void GetHigherEducation(boolean h)
    {
        if(h)
        {
            higherEducation_ = "да";
        }
        else
        {
            higherEducation_ = "нет";
        }
    }

    public Employee(String name, Boolean higherEducation, position posit, Integer sal) throws MyException {
       // this.name = name;
        this.setName(name);
        //this.higherEducation = higherEducation;
        //Posit = posit;
        this.setHigherEducation(higherEducation);
       // this.salary = sal;
        this.setSalary(sal);
        this.setPosit(posit);
        GetHigherEducation(higherEducation);
        logger.info("Сотрудник создан!");
    }

    public String getName() {
        return name;
    }

    public void setName(String name) throws MyException{
        if (name == "")
        {
            throw new MyException("Имя не может быть пустым!");
        }
        else {
            this.name = name;
        }
    }

    public Boolean getHigherEducation() {
        return higherEducation;
    }

    public void setHigherEducation(Boolean higherEducation) {
        this.higherEducation = higherEducation;
    }

    public position getPosit() {
        return Posit;
    }

    public void setPosit(position posit) {
        if (posit == position.middle) Posit = position.middle;
        if (posit == position.junior) Posit = position.junior;
        if (posit == position.senior) Posit = position.senior;
        if(posit == position.trainee) Posit = position.trainee;
    }

    public enum position {
            junior, senior, middle, trainee
    }

    // переопределение метода toString()
    @Override
    public String toString()
    {
        return "\nname: " + this.name + "\nHigher education: " + this.higherEducation_ + "\nPosition: "+ Posit + "\nSalary:" + this.salary + '\n';
    }
}
