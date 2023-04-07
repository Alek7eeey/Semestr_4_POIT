package com.example.lab_9;

import java.io.*;
import java.time.LocalDate;
import java.time.LocalTime;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

@WebServlet(name = "Lab_9", value = "/Lab_9")
public class Servlet1 extends HttpServlet {

    public Servlet1()
    {
        super();
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
      response.setContentType("text/html");
        String protocol = request.getProtocol();
        String ipAddress = request.getRemoteAddr();
        String clientName = request.getRemoteHost();
        String method = request.getMethod();
        String url = request.getRequestURL().toString();
        LocalTime currentTime = LocalTime.now();
        LocalDate currentDate = LocalDate.now();

        String queryString = request.getQueryString();

        PrintWriter out = response.getWriter();
        out.println("Time now: " + currentTime);
        out.println("Date now: " + currentDate);
        out.println("Protocol: " + protocol);
        out.println("IP Address: " + ipAddress);
        out.println("Client Name: " + clientName);
        out.println("Method: " + method);
        out.println("URL: " + url);
        out.println("Parametrs: " + queryString);
    }

    public void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType("text/html");
        response.getWriter().print("This is " + this.getClass().getName() + ", using the POST method");
    }

    @Override
    public void service(ServletRequest req, ServletResponse res) throws ServletException, IOException {
        super.service(req,res);
        System.out.println("service");
    }

    public void destroy(ServletRequest req, ServletResponse res)throws ServletException, IOException {
        super.destroy();
        System.out.println("destroy");
    }

    @Override
    public void init(ServletConfig config) throws ServletException {
        super.init(config);
        System.out.println("init");
    }
}