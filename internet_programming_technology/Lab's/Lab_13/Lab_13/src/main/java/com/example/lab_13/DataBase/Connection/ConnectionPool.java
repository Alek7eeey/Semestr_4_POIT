package com.example.lab_13.DataBase.Connection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class ConnectionPool {

    private static ConnectionPool connectionPool;
    private Connection connection;

    public static ConnectionPool getInstance() // Singleton
    {
        if (connectionPool == null) {
            connectionPool = new ConnectionPool();
        }
        return connectionPool;
    }

    public Connection GetConnectionString() {
        if (connection == null) {
            String connectionString = "jdbc:mysql://localhost:3306/football_teams?autoReconnect=true&useSSL=false";
            try {
                Class.forName("com.mysql.cj.jdbc.Driver");
                connection = DriverManager.getConnection(connectionString, "root", "Kravchenko1");
            } catch (ClassNotFoundException | SQLException e) {
                throw new RuntimeException(e);
            }
        }
        return connection;
    }

    public void destroy() throws SQLException {
        if (connection != null) {
            connection.close();
        }
    }

}
