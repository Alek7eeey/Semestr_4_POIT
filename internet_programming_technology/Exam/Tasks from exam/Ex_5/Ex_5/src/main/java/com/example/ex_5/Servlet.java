package com.example.ex_5;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;
import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;
import org.apache.log4j.xml.DOMConfigurator;

import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

@WebServlet(name = "Servlet", value = "/Servlet")
public class Servlet extends HttpServlet {
    static {
        new DOMConfigurator().doConfigure("D:/studing/4_semestr/internet_programming_technology/Exam/Tasks from exam/Ex_5/Ex_5/src/main/java/com/example/ex_5/log/log4j.xml", LogManager.getLoggerRepository());
    }
    private static final Logger LOG = Logger.getLogger(Servlet.class);
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        String role = request.getParameter("login");
        HttpSession session = request.getSession(true);
        String info = "";
        Boolean isTrue = false;
        int sessionTimeoutSeconds = 50;

        if(role.equals("admin"))
        {
            sessionTimeoutSeconds = 10; // Время сессии админа - 10 секунд
            info+="role: admin\n";
        }

        else if(role.equals("user"))
        {
            sessionTimeoutSeconds = 20; // Время сессии юзера - 20 секунд
            info+="role: user\n";
        }
        else{
            isTrue = true;
        }

        session.setMaxInactiveInterval(sessionTimeoutSeconds);

        if(!isTrue)
        {
            long creationTime = request.getSession().getCreationTime();
            Date date = new Date(creationTime);
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
            String formattedDate = sdf.format(date);

            info+="ID: "+request.getSession().getId() + "\n" + "Time creation: "+formattedDate + "\n" + "URI: "+request.getRequestURI();

            ServletContext servletContext = getServletContext();
            RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/main.jsp");
            request.setAttribute("description", info);
            LOG.info(info);
            requestDispatcher.forward(request, response);
        }
        else{
            ServletContext servletContext = getServletContext();
            RequestDispatcher requestDispatcher2 = servletContext.getRequestDispatcher("/error.jsp");
            request.setAttribute("name", "Вы ввели не правильный логин");
            requestDispatcher2.forward(request, response);
        }

    }


    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
