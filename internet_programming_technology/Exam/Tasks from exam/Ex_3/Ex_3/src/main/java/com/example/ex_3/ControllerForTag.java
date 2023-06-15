package com.example.ex_3;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;

@WebServlet(name = "ControllerForTag", value = "/ControllerForTag")
public class ControllerForTag extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String stroke = request.getParameter("numberDoc");
        String regex = "^\\d{4,6}/21-[A-Z]{4}$";
        if(stroke.matches(regex))
        {
            ServletContext servletContext = getServletContext();
            RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/result.jsp");
            request.setAttribute("name", "Все хорошо))");
            requestDispatcher.forward(request, response);


        }
        else
        {
            ((HttpServletResponse) response).sendRedirect("Errorpage.jsp");
        }
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
