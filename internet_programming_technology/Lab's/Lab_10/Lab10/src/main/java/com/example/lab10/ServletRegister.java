package com.example.lab10;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.*;

@WebServlet(name = "ServletRegister", value = "/ServletRegister")
public class ServletRegister extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        // устанавливаем атрибут в сессию
        HttpSession session = ((HttpServletRequest) request).getSession();
        Boolean loggedIn = (Boolean) session.getAttribute("loggedIn");
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();

        if(loggedIn != null && !loggedIn)
        {
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

                String userLogin = request.getParameter("userLogin");
                String userPassword = request.getParameter("userPassword");

                String sql2 = "insert into user(login, password)\n" +
                        "values\n" +
                        "(?, sha2(?, 256));";

                try (PreparedStatement statement = connection.prepareStatement(sql2)) {
                    statement.setString(1, userLogin);
                    statement.setString(2, userPassword);
                    int rowsAffected = statement.executeUpdate();


                    if (rowsAffected > 0) {
                        response.sendRedirect("register.jsp?error2=true");
                    }

                    else if(rowsAffected == 0) {
                        response.sendRedirect("register.jsp?error2=false");
                        ((HttpServletResponse) response).sendRedirect("index.jsp");
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

        else if(loggedIn != null && loggedIn)
        {
            response.sendRedirect("register.jsp?error2=true");
        }
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
