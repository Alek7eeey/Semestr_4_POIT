package com.example.ex_6;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.sql.*;

@WebServlet(name = "Servlet", value = "/Servlet")
public class Servlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        int like = 0, dislike = 0;
        String text = "";

        /*База данных*/
        ConnectionPool connection = new ConnectionPool();

        String sql = "select * from content;";
        try {
            Statement stmt = connection.GetConnectionString().createStatement();
            ResultSet result = stmt.executeQuery(sql);
            while (result.next()) {
                like = (result.getInt("likes"));
                dislike = (result.getInt("dislikes"));
                text = (result.getString("name"));
            }
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }

        String str = "Text: " + text + ", likes: " + like + ", dislikes: " + Integer.toString(dislike);

        ServletContext servletContext = getServletContext();
        RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/look.jsp");
        request.setAttribute("name", str);
        requestDispatcher.forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
