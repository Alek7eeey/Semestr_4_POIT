package com.example.lab_13.Tests;
import com.example.lab_13.Exceptions.StandartException;
import com.example.lab_13.Model.InfAboutUser;
import com.example.lab_13.Model.MyData;
import com.example.lab_13.Model.infAboutProducts;
import com.example.lab_13.Service.PersonService;
import com.example.lab_13.Service.ProductsService;
import org.testng.annotations.*;

import java.sql.SQLException;
import java.util.List;

import static org.testng.Assert.*;
import org.testng.Assert;
public class Test
{
    List<infAboutProducts> productsList;
    @BeforeMethod
    public void setUp() throws SQLException {
        productsList= ProductsService.GetProducts();
    }

    @AfterSuite
    public void end()
    {
        System.out.println("Тест закончен!");
    }

    @org.testng.annotations.Test
    public void IsEmpty()
    {
        assertTrue(productsList.isEmpty());
    }

    @org.testng.annotations.Test
    public void IsEmpty2() throws SQLException {
        MyData.ThisID = 2;
        productsList= ProductsService.GetProducts();
        assertTrue(productsList.isEmpty());
    }

    @org.testng.annotations.Test
    public void LoginUser() throws StandartException {
        InfAboutUser user = new InfAboutUser("admin", "admin12");
        assertTrue(PersonService.LogIn(user));
    }

    @org.testng.annotations.Test
    public void LoginUserError() throws StandartException {
        InfAboutUser user = new InfAboutUser("admin111", "admin12");
        assertTrue(PersonService.LogIn(user));
    }
}
