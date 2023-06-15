package com.example.ex_7;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

@WebServlet(name = "Servlet", value = "/Servlet")
public class Servlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        String year = request.getParameter("year");
        String sum = request.getParameter("sum");

        List<Credit> credits = new ArrayList<>();
        //DB
        ConnectionPool connectionPool = new ConnectionPool();
        Connection connection = connectionPool.GetConnectionString();

        String sql2 = "select * from credits where years like ? and sum > ?";

        PreparedStatement pstmt = null;
        try {
            pstmt = connection.prepareStatement(sql2);
            pstmt.setInt(1, Integer.parseInt(year));
            pstmt.setInt(2, Integer.parseInt(sum));
        } catch (SQLException ex) {
            throw new RuntimeException(ex);
        }
        try (ResultSet rs = pstmt.executeQuery()) {
            while (rs.next()) {
                Credit cr = new Credit();
                cr.sum = rs.getInt("sum");
                cr.year = rs.getInt("years");
                credits.add(cr);
            }
            rs.close();
            pstmt.close();
        }
        catch (SQLException e) {
            e.printStackTrace();
        }

        //resultir sum
        int sumResult = 0;
        for (var a: credits
             ) {
            sumResult += a.sum;
        }
        //передать дальше

        if(sumResult>0)
        {
            request.setAttribute("lst", credits);
            request.setAttribute("sum", sumResult);
            request.getRequestDispatcher("indo.jsp").forward(request, response);
        }

        else {
            ServletContext servletContext = getServletContext();
            RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/error.jsp");
            request.setAttribute("name", "Результрующая сумма меньше нуля");
            requestDispatcher.forward(request, response);
        }

    }


    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
