package com.example.lab_9;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.io.PrintWriter;

@WebServlet(name = "Servlet3_2", value = "/Servlet3_2")
public class Servlet3_2 extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html");
        PrintWriter writer = response.getWriter();
        String p1 = (String) request.getAttribute("param1");
        String p2 = (String) request.getAttribute("param2");

        try {
            writer.println("<h2>Параметр: " + p1 + "</h2>");
            writer.println("<h2>Параметр: " + p2 + "</h2>");
        } finally {
            writer.close();
        }
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
