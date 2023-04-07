package com.example.lab_9;

import jakarta.servlet.*;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;

import java.io.IOException;
import java.sql.*;


public class InputFilter implements Filter {
    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain)
            throws IOException, ServletException {
        String connectionString = "jdbc:mysql://localhost:3306/java?autoReconnect=true&useSSL=false";

        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
        } catch (ClassNotFoundException e) {
            throw new RuntimeException(e);
        }

        try (Connection connection = DriverManager.getConnection(connectionString, "root", "Kravchenko1")) {
            request.setCharacterEncoding("UTF-8");
            response.setContentType("text/html; charset=UTF-8");

            String userLogin = request.getParameter("userLogin");
            String userPassword = request.getParameter("userPassword");

            String sql = "SELECT typeOfUser FROM users WHERE username = ? AND password = SHA2(?, 256)";

            try (PreparedStatement statement = connection.prepareStatement(sql)) {
                statement.setString(1, userLogin);
                statement.setString(2, userPassword);
                ResultSet result = statement.executeQuery();

                if (result.next()) {
                    // устанавливаем атрибут в сессию
                    HttpSession session = ((HttpServletRequest) request).getSession();
                    session.setAttribute("loggedIn", true);

                }
                else {
                    HttpSession session = ((HttpServletRequest) request).getSession();
                    session.setAttribute("loggedIn", false);
                }

                chain.doFilter(request, response);
            }
            catch (SQLException e) {
                e.printStackTrace();
            }
        }
        catch (SQLException e) {
            e.printStackTrace();
        }
    }
}