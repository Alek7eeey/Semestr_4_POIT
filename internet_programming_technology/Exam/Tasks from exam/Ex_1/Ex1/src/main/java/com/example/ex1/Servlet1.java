package com.example.ex1;

import java.io.*;
import java.sql.*;

import jakarta.servlet.RequestDispatcher;
import jakarta.servlet.ServletContext;
import jakarta.servlet.ServletException;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;
import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;
import org.apache.log4j.xml.DOMConfigurator;

@WebServlet(name = "Servlet1", value = "/servlet1")
public class Servlet1 extends HttpServlet {
    private String message;
    static {
        new DOMConfigurator().doConfigure("D:/studing/4_semestr/internet_programming_technology/Exam/Tasks from exam/Ex_1/Ex1/src/main/java/com/example/ex1/logINFO/log4j.xml", LogManager.getLoggerRepository());
    }

    private static final Logger LOG = Logger.getLogger(Servlet1.class);

    public void init() {
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        LOG.info("Start Servlet 1");
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
        }
        catch (ClassNotFoundException e) {
            throw new RuntimeException(e);
        }

        String userLogin = request.getParameter("userLogin");

        DataBaseConnection connectionString = new DataBaseConnection();
        try (Connection connection = connectionString.GetConnectionString()) {
            request.setCharacterEncoding("UTF-8");
            response.setContentType("text/html; charset=UTF-8");

            String sql2 = "select * from users where login like ?";
            PreparedStatement pstmt = connection.prepareStatement(sql2);
            pstmt.setString(1, userLogin);
            try (ResultSet rs = pstmt.executeQuery()) {
                if (rs.next()) {
                    ServletContext servletContext = request.getServletContext();
                    GlobalInfo.type = userLogin;
                    RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/action.jsp");
                    requestDispatcher.forward(request, response);
                }
                else {
                    ServletContext servletContext = request.getServletContext();
                    RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/error.jsp");
                    request.setAttribute("name", "Ошибка при авторизации");
                    requestDispatcher.forward(request, response);
                }
                rs.close();
                pstmt.close();
            }
            catch (SQLException e) {
                e.printStackTrace();
            } catch (ServletException e) {
                throw new RuntimeException(e);
            }
        }
        catch (SQLException e) {
            throw new RuntimeException(e);
        }


    }

    public void destroy() {
    }
}