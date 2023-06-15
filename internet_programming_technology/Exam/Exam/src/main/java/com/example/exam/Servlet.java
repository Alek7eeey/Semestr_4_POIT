package com.example.exam;

import com.example.exam.DataBase.ConnectionPool;
import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;
import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;
import org.apache.log4j.xml.DOMConfigurator;

import java.io.IOException;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.LocalTime;
import java.util.Date;

@WebServlet(name = "Servlet", value = "/Servlet")
public class Servlet extends HttpServlet {

    static {
        new DOMConfigurator().doConfigure("D:/studing/4_semestr/internet_programming_technology/Exam/Tasks from exam/Ex_1/Ex1/src/main/java/com/example/ex1/logINFO/log4j.xml", LogManager.getLoggerRepository());
    }

    private static final Logger LOG = Logger.getLogger(Servlet.class);
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        String id = request.getParameter("id");

        /*String protocol = request.getProtocol();
        String ipAddress = request.getRemoteAddr();
        String clientName = request.getRemoteHost();
        String method = request.getMethod();
        String url = request.getRequestURL().toString();
        LocalTime currentTime = LocalTime.now();
        LocalDate currentDate = LocalDate.now();

        long creationTime = request.getSession().getCreationTime();
        Date date = new Date(creationTime);
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        String formattedDate = sdf.format(date);*/

        //LOG.info("Start query 2");

        //DataBase

        String fio = "";
        ConnectionPool connection = new ConnectionPool();
        String sql2 = "select * from student where id like ?";
        PreparedStatement pstmt = null;
        try {
            pstmt = connection.GetConnectionString().prepareStatement(sql2);
        } catch (SQLException ex) {
            throw new RuntimeException(ex);
        }
        try {
            pstmt.setString(1, id);
        } catch (SQLException ex) {
            throw new RuntimeException(ex);
        }
        try (ResultSet rs = pstmt.executeQuery()) {
            if (rs.next()) {
                fio = rs.getString("fio");
            }
            rs.close();
            pstmt.close();
    }
        catch (SQLException e) {
        throw new RuntimeException(e);
    }

        if(!fio.isEmpty())
        {

            ServletContext servletContext = getServletContext();
            RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/person.jsp");
            request.setAttribute("name", fio);
            requestDispatcher.forward(request, response);
        }

        else
        {
            ServletContext servletContext = getServletContext();
            RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/Error.jsp");
            request.setAttribute("name", "Ошибка, такого id нету!(((");
            requestDispatcher.forward(request, response);
        }

}

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }

    private Cookie getCookie(HttpServletRequest request, String cookieName) {
        Cookie[] cookies = request.getCookies();
        if (cookies != null) {
            for (Cookie cookie : cookies) {
                if (cookie.getName().equals(cookieName)) {
                    return cookie;
                }
            }
            return null;
        }
        return null;
    }

}
