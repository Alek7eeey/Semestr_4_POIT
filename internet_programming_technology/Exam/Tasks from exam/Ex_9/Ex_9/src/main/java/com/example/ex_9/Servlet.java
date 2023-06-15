package com.example.ex_9;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;

@WebServlet(name = "Servlet", value = "/Servlet")
public class Servlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        String par = (String) request.getAttribute("par");
        ServletContext servletContext = getServletContext();

        if(par.equals("true"))
        {
            RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/Hello.jsp");
            requestDispatcher.forward(request, response);
        }

        else
        {
            RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/Error.jsp");
            request.setAttribute("name", "error because empty!");
            requestDispatcher.forward(request, response);
        }
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
