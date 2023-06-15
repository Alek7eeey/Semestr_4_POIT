package com.example.ex_8;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;

@WebServlet(name = "Servlet", value = "/Servlet")
public class Servlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String param = request.getParameter("get");
        String ip2 = request.getRemoteAddr();
        String ip = ip2.replaceAll(":", ".");
        int visitCount = 1;
        Cookie visitCountCookie = getCookie(request, ip);

        if (visitCountCookie != null) {
            try {
                visitCount = Integer.parseInt(visitCountCookie.getValue());
                visitCount++;
            } catch (NumberFormatException e) {

            }
        }
        else {

        }

        // Создаем Cookie для количества посещений
        Cookie newVisitCountCookie = new Cookie(ip, String.valueOf(visitCount));
        newVisitCountCookie.setMaxAge(150 * 60 * 60);

        response.addCookie(newVisitCountCookie);

        String inf1 = "Вы посещали эту страницу " + visitCount + "раз, ваш ip: " + ip + ", ваш протокол: " + request.getProtocol() + ", метод get";
        String inf2 = "Вы посещали эту страницу " + visitCount + "раз, ваш ip: " + ip + ", ваш заголовок: " + request.getRequestURI() + ", метод post";
            if(param != null)
            {
                ServletContext servletContext = getServletContext();
                RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/action.jsp");
                request.setAttribute("name", inf1);
                requestDispatcher.forward(request, response);
            }
            else
            {
                ServletContext servletContext = getServletContext();
                RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher("/action.jsp");
                request.setAttribute("name", inf2);
                requestDispatcher.forward(request, response);
            }
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
    }

    private Cookie getCookie(HttpServletRequest request, String cookieName) {
        Cookie[] cookies = request.getCookies();
        if (cookies != null) {
            for (Cookie cookie : cookies) {
                if (cookie.getName().equals(cookieName)) {
                    return cookie;
                }
            }
            return null;
        }
        return null;
    }
}
