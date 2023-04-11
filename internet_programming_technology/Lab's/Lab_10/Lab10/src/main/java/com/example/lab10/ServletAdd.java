package com.example.lab10;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

@WebServlet(name = "ServletAdd", value = "/ServletAdd")
public class ServletAdd extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        String connectionString = "jdbc:mysql://localhost:3306/football_teams?autoReconnect=true&useSSL=false";
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
        }
        catch (ClassNotFoundException e) {
            throw new RuntimeException(e);
        }

        try (Connection connection = DriverManager.getConnection(connectionString, "root", "Kravchenko1")) {
            request.setCharacterEncoding("UTF-8");
            response.setContentType("text/html; charset=UTF-8");

            String name = request.getParameter("name");
            int count = Integer.parseInt(request.getParameter("count"));
            String city = request.getParameter("city");

            String sql2 = "INSERT INTO footballTeams (name, countOfPlayers, city, userID) VALUES" +
                    "(?, ?, ?, ?);";

            try (PreparedStatement statement = connection.prepareStatement(sql2)) {
                statement.setString(1, name);
                statement.setInt(2, count);
                statement.setString(3, city);
                statement.setInt(4, MyData.ThisID);
                int rowsAffected = statement.executeUpdate();


                if (rowsAffected > 0)
                {
                    //response.sendRedirect("index.jsp?error3=false");
                    ServletContext servletContext = getServletContext();
                    RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/ServletLogin");
                    request.setAttribute("userLogin", MyData.ThisName);
                    requestDispatcher.forward(request, response);
                }

                else
                {
                    response.sendRedirect("index.jsp?error3=true");
                }


            }
            catch (SQLException e) {
                e.printStackTrace();
            }
        }
        catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
