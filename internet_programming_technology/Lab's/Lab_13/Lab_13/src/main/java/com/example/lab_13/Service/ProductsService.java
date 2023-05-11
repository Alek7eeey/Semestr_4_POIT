package com.example.lab_13.Service;

import com.example.lab_13.DataBase.Repository.RepositoryProducts;
import com.example.lab_13.Model.MyData;
import com.example.lab_13.Model.infAboutProducts;

import java.sql.SQLException;
import java.util.List;

public class ProductsService {
    public static List<infAboutProducts> GetProducts() throws SQLException {
        return RepositoryProducts.getAllproducts();
    }

    public static boolean AddProduct(infAboutProducts product)
    {
        try{
            RepositoryProducts.AddFootballTeam(product.name, product.count, product.city, MyData.ThisID);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static boolean removeProduct(String name)
    {
        try{
            RepositoryProducts.RemoveTeam(name);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
