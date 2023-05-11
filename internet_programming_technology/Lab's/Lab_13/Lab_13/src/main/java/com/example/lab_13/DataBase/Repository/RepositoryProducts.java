package com.example.lab_13.DataBase.Repository;

import com.example.lab_13.DataBase.Connection.ConnectionPool;
import com.example.lab_13.Exceptions.ExceptionSQL;
import com.example.lab_13.Model.InfAboutUser;
import com.example.lab_13.Model.MyData;
import com.example.lab_13.Model.infAboutProducts;
import jakarta.servlet.RequestDispatcher;
import jakarta.servlet.ServletContext;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

public class RepositoryProducts {
    public static List<infAboutProducts> getAllproducts() throws SQLException, ExceptionSQL {
        List<infAboutProducts> products = new ArrayList<>();
        ConnectionPool connection = ConnectionPool.getInstance();
        Statement stmt = connection.GetConnectionString().createStatement();
        String sql2 = "select f.id, f.name, f.countOfPlayers, f.city from \n" +
                "user u inner join footballTeams f \n" +
                "on u.id = f.userID\n" +
                "where u.id = "+ Integer.toString(MyData.ThisID) + ";";

        try (ResultSet rs = stmt.executeQuery(sql2)) {
            while (rs.next()) {
                infAboutProducts myProduct = new infAboutProducts();
                myProduct.setId(rs.getInt("id"));
                myProduct.setName(rs.getString("name"));
                myProduct.setCity(rs.getString("city"));
                myProduct.setCount(rs.getInt("countOfPlayers"));
                products.add(myProduct);

            }
            rs.close();
            stmt.close();
        }
        catch (ExceptionSQL e) {
            throw new ExceptionSQL("Ошибка при получении списка команда из БД", e);
        }
        return products;
    }

    public static boolean RemoveTeam(String name) throws ExceptionSQL {
        ConnectionPool connection = ConnectionPool.getInstance();
        String sql2 = "delete from footballTeams where footballTeams.name = ?;";
        try (PreparedStatement statement = connection.GetConnectionString().prepareStatement(sql2)) {
            statement.setString(1, name);
            int rowsAffected = statement.executeUpdate();


            if (rowsAffected > 0)
            {
               return true;
            }

            else
            {
               return false;
            }


        }
        catch (ExceptionSQL e) {
            throw new ExceptionSQL("Ошибка при удалении команды из списка", e);
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    public static boolean AddFootballTeam(String name, int countOfPlayers, String city, int userID) throws SQLException {
        ConnectionPool connection = ConnectionPool.getInstance();
        String sql2 = "INSERT INTO footballTeams (name, countOfPlayers, city, userID) VALUES" +
                "(?, ?, ?, ?);";
        try (PreparedStatement statement = connection.GetConnectionString().prepareStatement(sql2)) {
            statement.setString(1, name);
            statement.setInt(2, countOfPlayers);
            statement.setString(3, city);
            statement.setInt(4, MyData.ThisID);
            int rowsAffected = statement.executeUpdate();

            if (rowsAffected > 0)
            {
              return true;
            }

            else
            {
                return false;
            }


        }
        catch (ExceptionSQL e) {
            throw new ExceptionSQL("Ошибка при добавлении команды в список", e);
        }
    }
}
