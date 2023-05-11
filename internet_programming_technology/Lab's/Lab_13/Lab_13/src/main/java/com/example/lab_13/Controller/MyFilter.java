package com.example.lab_13.Controller;

import com.example.lab_13.DataBase.Connection.ConnectionPool;
import com.example.lab_13.Model.MyData;

import jakarta.servlet.*;
import jakarta.servlet.annotation.*;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpSession;

import java.io.IOException;
import java.sql.*;
import java.time.LocalTime;

@WebFilter(filterName = "MyFilter")
public class MyFilter implements Filter {
    public void init(FilterConfig config) throws ServletException {

    }

    public void destroy() {
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws ServletException, IOException {
        MyData.isRegister = false;
        HttpServletRequest httpRequest = (HttpServletRequest) request;
        String url = httpRequest.getRequestURL().toString();

        if (url.equals("http://localhost:8080/Lab_13-1.0-SNAPSHOT/welcome.jsp") && !MyData.isRegister) {
            request.setAttribute("name", "Нет авторизации для выполнения данной команды");
            RequestDispatcher dispatcher = request.getRequestDispatcher("/errorPage.jsp");
            dispatcher.forward(request, response);
        }


    }
}
