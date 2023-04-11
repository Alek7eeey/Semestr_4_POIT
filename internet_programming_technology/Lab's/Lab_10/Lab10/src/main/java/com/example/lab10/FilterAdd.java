package com.example.lab10;

import jakarta.servlet.*;
import jakarta.servlet.annotation.*;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;
import org.apache.log4j.xml.DOMConfigurator;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.*;
import java.time.LocalTime;

import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;
import org.apache.log4j.xml.DOMConfigurator;
@WebFilter(filterName = "FilterAdd")
public class FilterAdd implements Filter {

    static {
        new DOMConfigurator().doConfigure("D:/studing/4_semestr/internet_programming_technology/Lab's/Lab_10/Lab10/src/main/java/com/example/lab10/log/log4j.xml", LogManager.getLoggerRepository());
    }
    private static final Logger LOG = Logger.getLogger(FilterAdd.class);

    public void init(FilterConfig config) throws ServletException {
    }

    public void destroy() {
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws ServletException, IOException {
        MyData.isRegister = false;
        HttpServletRequest httpRequest = (HttpServletRequest) request;
        String url = httpRequest.getRequestURL().toString();

        if (url.equals("http://localhost:8080/Lab10-1.0-SNAPSHOT/welcome.jsp") && !MyData.isRegister) {
            RequestDispatcher dispatcher = request.getRequestDispatcher("/errorPage.jsp");
            dispatcher.forward(request, response);
        }

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
            MyData.ThisName = userLogin;
            String userPassword = request.getParameter("userPassword");

            String sql = "SELECT id FROM user WHERE login = ? AND password = SHA2(?, 256)";

            try (PreparedStatement statement = connection.prepareStatement(sql)) {
                statement.setString(1, userLogin);
                statement.setString(2, userPassword);
                ResultSet result = statement.executeQuery();

                if(userLogin != null && userPassword != null) {
                    if (result.next()) {
                        HttpSession session = ((HttpServletRequest) request).getSession();
                        session.setAttribute("loggedIn", true);
                        MyData.ThisID = result.getInt("id");
                        MyData.isRegister = true;
                    } else {
                        HttpSession session = ((HttpServletRequest) request).getSession();
                        session.setAttribute("loggedIn", false);
                    }
                }
                chain.doFilter(request, response);
            }
            catch (SQLException e) {
                e.printStackTrace();
            }
        }
        catch (SQLException e) {
            throw new RuntimeException(e);
        }

        String servletPath = httpRequest.getServletPath();
        String method = httpRequest.getMethod();
        String timeStamp = LocalTime.now().toString();
        String remoteAddress = request.getRemoteAddr();

        LOG.info("Log: " +servletPath + method + timeStamp + remoteAddress);
    }
}
