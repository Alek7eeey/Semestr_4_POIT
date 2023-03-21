package by.comapany;

import by.employee.employee;
import org.testng.Assert;
import org.testng.annotations.*;

import java.util.ArrayList;

import static org.testng.Assert.*;
import java.util.ArrayList;

import java.util.ArrayList;


public class company {
    public String nameCompany;
    public ArrayList<employee> arrEmpl = new ArrayList<employee>();



    public void addNewEmployee(employee em)
    {
        arrEmpl.add(em);

    }

    public void removeEmployee(employee em)
    {
        if(arrEmpl.contains(em)) {
            arrEmpl.remove(em);
        }
        else
        {
            System.out.println("Такого сотрудника нету!");
        }
    }

    public String getAllEmpl()
    {
        String sb = "";
        for (var a : arrEmpl) {
            sb+=a.name + " ";
            sb+=Integer.toString(a.yearExp) + " ";
            sb+=Boolean.toString(a.education) + " ";
            sb+="\n";
        }
        return sb;
    }

    public void getEmplWithHigherEducation()
    {
        for (var a: arrEmpl
        ) {
            if(a.education) {
                a.toString();
            }
        }
    }

    public void getEmplWithWorkExp(int exp)
    {
        for (var a: arrEmpl
        ) {
            if (a.yearExp >= exp) {
                a.toString();
            }
        }
    }


}


