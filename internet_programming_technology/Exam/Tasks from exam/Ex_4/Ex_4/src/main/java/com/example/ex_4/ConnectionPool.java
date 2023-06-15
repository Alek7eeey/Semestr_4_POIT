package com.example.ex_4;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class ConnectionPool {

    private Connection connection;
    public Connection GetConnectionString() {
        if (connection == null) {
            String connectionString = "jdbc:mysql://localhost:3306/examdb?autoReconnect=true&useSSL=false";
            try {
                Class.forName("com.mysql.cj.jdbc.Driver");
                connection = DriverManager.getConnection(connectionString, "root", "Kravchenko1");
            } catch (ClassNotFoundException | SQLException e) {
                throw new RuntimeException(e);
            }
        }
        return connection;
    }
}
