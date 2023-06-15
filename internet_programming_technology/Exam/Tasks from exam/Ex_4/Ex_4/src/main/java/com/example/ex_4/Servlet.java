package com.example.ex_4;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

@WebServlet(name = "Servlet", value = "/Servlet")
public class Servlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String parametr = request.getParameter("golos");
        ConnectionPool connection = new ConnectionPool();
        try {
            String sql = "update candidats set candidats.count = candidats.count + 1 WHERE name = ?";
            try (PreparedStatement statement = connection.GetConnectionString().prepareStatement(sql)) {

                switch (parametr){
                    case "tih":  statement.setString(1, "Тихановская"); break;
                    case "bab":  statement.setString(1, "Бабарико"); break;
                    case "cep":  statement.setString(1, "Цепкало"); break;
                    case "dmi":  statement.setString(1, "Дмитриев"); break;
                }
                int rowsAffected = statement.executeUpdate();
                Statement stmt = connection.GetConnectionString().createStatement(); // получили строку подключение, которая выше в примере
                String sql2 = "select * from candidats \n;";

                List<President> presidentList = new ArrayList<>();

                try (ResultSet rs = stmt.executeQuery(sql2)) {
                    while (rs.next()) {
                        President pr = new President();
                        pr.setGolos(rs.getDouble("count"));
                        pr.setName(rs.getString("name"));
                        presidentList.add(pr);
                    }

                    rs.close();
                    stmt.close();
                }


                if (rowsAffected > 0)
                {
                    request.setAttribute("lst", presidentList);
                    request.getRequestDispatcher("Info.jsp").forward(request, response);
                }

                else
                {
                    ServletContext servletContext = getServletContext();
                    RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/error.jsp");
                    request.setAttribute("name", "Ошибка при голосвании");
                    requestDispatcher.forward(request, response);
                }
            }


        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
