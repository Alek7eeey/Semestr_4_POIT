package com.example.ex_9;

import jakarta.servlet.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;

@WebFilter(filterName = "Filter2")
public class Filter2 implements Filter {
    public void init(FilterConfig config) throws ServletException {
    }

    public void destroy() {
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws ServletException, IOException {
        String p1 = request.getParameter("login");
        String p2 = request.getParameter("password");

        if(p1 == null || p2 == null || p1.isEmpty() || p2.isEmpty())
        {
            request.setAttribute("par","false");
            chain.doFilter(request, response);
        }
        else
        {
            request.setAttribute("par","true");
            chain.doFilter(request, response);
        }
    }
}
