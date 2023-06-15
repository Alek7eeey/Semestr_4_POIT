package com.example.ex_9;

import jakarta.servlet.*;
import jakarta.servlet.annotation.*;
import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;
import org.apache.log4j.xml.DOMConfigurator;

import java.io.IOException;
import java.time.LocalTime;

@WebFilter(filterName = "Filter1")
public class Filter1 implements Filter {
    public void init(FilterConfig config) throws ServletException {
    }

    public void destroy() {
    }
    static {
        new DOMConfigurator().doConfigure("D:/studing/4_semestr/internet_programming_technology/Exam/Tasks from exam/Ex_9/Ex_9/src/main/java/com/example/ex_9/log/log4j.xml", LogManager.getLoggerRepository());
    }
    private static final Logger LOG = Logger.getLogger(Filter1.class);
    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws ServletException, IOException {
        LocalTime time = LocalTime.now();
        String ip = request.getRemoteAddr();
        LOG.info("Start filter 1" + ", time: " + time + ", ip: " + ip);
        chain.doFilter(request, response);
    }
}
