package com.example.lab_9;


import jakarta.servlet.*;
import jakarta.servlet.http.HttpServletRequest;
import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;
import org.apache.log4j.xml.DOMConfigurator;

import java.io.IOException;
import java.time.LocalTime;

public class logFilter implements Filter {
    static {
        new DOMConfigurator().doConfigure("D:/studing/4_semestr/internet_programming_technology/Lab's/Lab_9/Lab_9/src/main/java/com/example/lab_9/log/log4j.xml", LogManager.getLoggerRepository());
    }
    private static final Logger LOG = Logger.getLogger(logFilter.class);

    @Override
    public void init(FilterConfig config) throws ServletException {
    }

    @Override
    public void doFilter(ServletRequest servletRequest, ServletResponse servletResponse, FilterChain filterChain) throws IOException, ServletException
    {
        HttpServletRequest httpRequest = (HttpServletRequest) servletRequest;

        String servletPath = httpRequest.getServletPath();
        String method = httpRequest.getMethod();
        String timeStamp = LocalTime.now().toString();
        String remoteAddress = servletRequest.getRemoteAddr();

        LOG.info("Log: " +servletPath + method + timeStamp + remoteAddress);

        filterChain.doFilter(servletRequest,servletResponse);
    }
}
