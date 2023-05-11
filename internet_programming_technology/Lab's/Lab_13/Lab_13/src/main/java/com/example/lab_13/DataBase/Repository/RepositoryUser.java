package com.example.lab_13.DataBase.Repository;

import com.example.lab_13.DataBase.Connection.ConnectionPool;
import com.example.lab_13.Model.MyData;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class RepositoryUser {
    public static boolean AddUserToDb(String login, String password)
    {
        String sql2 = "insert into user(login, password)\n" +
                "values\n" +
                "(?, sha2(?, 256));";
        ConnectionPool connection = ConnectionPool.getInstance();
        try (PreparedStatement statement = connection.GetConnectionString().prepareStatement(sql2)) {
            statement.setString(1, login);
            statement.setString(2, password);
            int rowsAffected = statement.executeUpdate();


            if (rowsAffected > 0) {
               return true;
            }

            else if(rowsAffected == 0) {
                return false;
            }


        }
        catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }

    public static boolean LogInUser(String login, String password)
    {
        String sql = "SELECT id FROM user WHERE login = ? AND password = SHA2(?, 256)";
        ConnectionPool connection = ConnectionPool.getInstance();
        try (PreparedStatement statement = connection.GetConnectionString().prepareStatement(sql)) {
            statement.setString(1, login);
            statement.setString(2, password);
            ResultSet result = statement.executeQuery();

            if(login != null && password != null) {
                if (result.next()) {
                    MyData.ThisID = result.getInt("id");
                    MyData.isRegister = true;
                    MyData.ThisName = login;
                   return true;
                }
                else {
                    return false;
                }
            }
        }
        catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }

}
