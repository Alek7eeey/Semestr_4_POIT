package com.example.lab_12;

import java.io.*;
import java.util.ArrayList;

import jakarta.servlet.ServletException;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

@WebServlet(name = "Servlet", value = "/Servlet")
public class Servlet extends HttpServlet {
    public ArrayList<People> peoples = new ArrayList<>();


    public void init() {

    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {

        peoples.add(new People("Aleksey", 19, 'm'));
        peoples.add(new People("Dmitry", 26, 'm'));
        peoples.add(new People("Daria", 16, 'g'));
        request.setAttribute("lst", peoples);
        request.getRequestDispatcher("Core.jsp").forward(request, response);
    }

    public void destroy() {
    }
}