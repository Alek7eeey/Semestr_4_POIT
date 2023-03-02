package by.Lab_4.Employee;

import jakarta.xml.bind.annotation.XmlRootElement;

import java.util.List;

public class Employee {
    private String name;
    private boolean higherEducation;
    private String position;
    private int salary;

    public Employee(String name, boolean higherEducation, String position, int salary) {
        this.name = name;
        this.higherEducation = higherEducation;
        this.position = position;
        this.salary = salary;
    }

    public Employee(){}
    public String getName() {
        return name;
    }

    public boolean hasHigherEducation() {
        return higherEducation;
    }

    public String getPosition() {
        return position;
    }

    public int getSalary() {
        return salary;
    }

    @Override
    public String toString() {
        return "Employee{" +
                "name='" + name + '\'' +
                ", higherEducation=" + higherEducation +
                ", position='" + position + '\'' +
                ", salary=" + salary +
                '}';
    }

    private List<Employee> employeeList;

    public List<Employee> getEmployeeList() {
        return employeeList;
    }

    public void setEmployeeList(List<Employee> employeeList) {
        this.employeeList = employeeList;
    }
}