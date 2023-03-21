package by.test;
import by.comapany.company;
import by.employee.employee;
import com.beust.jcommander.Parameter;
import org.testng.Assert;
import org.testng.annotations.*;
import java.util.ArrayList;

import static org.testng.Assert.*;
public class testCompany {
    private company testCompany;
    private employee testEmployee1;
    private employee testEmployee2;

    @BeforeMethod
    public void setUp() {
        testCompany = new company();
        testEmployee1 = new employee("John", 15, true);
        testEmployee2 = new employee("Vadim", 5, false);
    }

    @AfterSuite
    public void end()
    {
        System.out.println("Тест закончен!");
    }

    @Test (enabled = false) //не будет выполняться
    public void addNewEmployee() {
        testCompany.addNewEmployee(testEmployee1);
        assertTrue(testCompany.arrEmpl.contains(testEmployee1));
    }

    @Test(timeOut = 1100)
    public void removeEmployee() throws InterruptedException {
        testCompany.arrEmpl.add(testEmployee1);
        testCompany.removeEmployee(testEmployee1);
        Thread.sleep(1000); //эмуляция затраты времения для тайм аута
        assertFalse(testCompany.arrEmpl.contains(testEmployee1));
    }

    @Test
    public void removeNonexistentEmployee() {
        testCompany.removeEmployee(testEmployee1);
        assertFalse(testCompany.arrEmpl.contains(testEmployee1));
    }


    @Test
    public void testGetAllEmpl() {
        testCompany.addNewEmployee(testEmployee1);
       // testCompany.addNewEmployee(testEmployee2);
        String str = "John 15 true \n";
        assertEquals(str, testCompany.getAllEmpl());
    }

}
