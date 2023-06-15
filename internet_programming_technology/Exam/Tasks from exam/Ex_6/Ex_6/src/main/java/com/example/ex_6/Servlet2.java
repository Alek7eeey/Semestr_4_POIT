package com.example.ex_6;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

@WebServlet(name = "Servlet2", value = "/Servlet2")
public class Servlet2 extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        int like = 0, dislike = 0;
        String text = "";

        /*База данных*/
        ConnectionPool connection = new ConnectionPool();
        String sqldlike = "Update content set likes = likes + 1;";

        try (PreparedStatement statement = connection.GetConnectionString().prepareStatement(sqldlike)) {
            int rowsAffected = statement.executeUpdate();


            if (rowsAffected > 0)
            {

            }

            else
            {

            }
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }

        Statement stmt = null; // получили строку подключение, которая выше в примере
        try {
            stmt = connection.GetConnectionString().createStatement();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
        String sql = "select * from content;";

        try (ResultSet rs = stmt.executeQuery(sql)) {
            while (rs.next()) {
                like = (rs.getInt("likes"));
                dislike = (rs.getInt("dislikes"));
                text = (rs.getString("name"));
            }
            rs.close();
            stmt.close();
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
