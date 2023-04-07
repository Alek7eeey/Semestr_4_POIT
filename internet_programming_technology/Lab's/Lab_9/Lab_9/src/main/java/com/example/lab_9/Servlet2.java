package com.example.lab_9;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.sql.Connection;
import java.sql.DriverManager;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.*;
import java.time.LocalDate;
import java.time.LocalTime;

@WebServlet(name = "Servlet2", value = "/Servlet2")
public class Servlet2 extends HttpServlet {
    public Servlet2()
    {
        super();
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String connectionString = "jdbc:mysql://localhost:3306/java?autoReconnect=true&useSSL=false";

        // устанавливаем атрибут в сессию
        HttpSession session = ((HttpServletRequest) request).getSession();
        Boolean loggedIn = (Boolean) session.getAttribute("loggedIn");

        try
        {
            Class.forName("com.mysql.cj.jdbc.Driver");
        }
        catch (ClassNotFoundException e)
        {
            throw new RuntimeException(e);
        }

        try (Connection connection = DriverManager.getConnection(connectionString, "root", "Kravchenko1"))
        {
            request.setCharacterEncoding("UTF-8");
            response.setContentType("text/html; charset=UTF-8");
            String action = request.getParameter("action");

            String userLogin = request.getParameter("userLogin");
            String userPassword = request.getParameter("userPassword");

            String sql = "SELECT typeOfUser FROM users WHERE username = ? AND password = SHA2(?, 256)";

            if (loggedIn != null && loggedIn && "login".equals(action))
            {
                try (PreparedStatement statement = connection.prepareStatement(sql)) {
                    statement.setString(1, userLogin);
                    statement.setString(2, userPassword);
                    ResultSet result = statement.executeQuery();

                    if (result.next()) {
                        LocalTime time = LocalTime.now();
                        LocalDate date = LocalDate.now();
                        response.setContentType("text/html;charset=UTF-8");
                        PrintWriter out = response.getWriter();
                        out.println("<html>");
                        out.println("<head>");
                        out.println("<title>Результат отправки формы входа</title>");
                        out.println("</head>");
                        out.println("<body>");
                        out.println("<h1>Добро пожаловать!</h1>");
                        out.println("<p>Ваш логин: " + userLogin + "</p>");
                        out.println("<p>Ваш пароль: " + userPassword + "</p>");
                        out.println("<p>Ваша роль: " + result.getString("typeOfUser") + "</p>");
                        out.println("<p>Текущее время: " + time + "</p>");
                        out.println("<p>Текущее дата: " + date + "</p>");
                        out.println("</body>");
                        out.println("</html>");

                        //ФАЙЛЫ cookie

                        // Получаем объект Cookie для последнего сеанса пользователя
                        Cookie lastVisitCookie = getCookie(request, "lastVisit"+userLogin+userPassword);

                        // Получаем текущую дату и время
                        LocalTime time2 = LocalTime.now();
                        String currentDateTime = time2.toString();

                        // Получаем количество посещений из Cookie
                        int visitCount = 1;
                        Cookie visitCountCookie = getCookie(request, "visitCount"+userLogin+userPassword);
                        if (visitCountCookie != null) {
                            try {
                                visitCount = Integer.parseInt(visitCountCookie.getValue());
                                visitCount++;
                            } catch (NumberFormatException e) {

                            }
                        }

                        // Получаем тип пользователя
                        String userType = result.getString("typeOfUser");

                        // Создаем Cookie для даты последнего посещения
                        Cookie newLastVisitCookie = new Cookie("lastVisit"+userLogin+userPassword, currentDateTime);
                        newLastVisitCookie.setMaxAge(150 * 60 * 60); // время жизни Cookie - 150 часов

                        // Создаем Cookie для количества посещений
                        Cookie newVisitCountCookie = new Cookie("visitCount"+userLogin+userPassword, String.valueOf(visitCount));
                        newVisitCountCookie.setMaxAge(150 * 60 * 60);

                        // Создаем Cookie для типа пользователя
                        Cookie newTypeOfUserCookie = new Cookie("userType", userType);
                        newTypeOfUserCookie.setMaxAge(150 * 60 * 60);

                        // Добавляем созданные Cookie в объект HttpServletResponse
                        response.addCookie(newLastVisitCookie);
                        response.addCookie(newVisitCountCookie);
                        response.addCookie(newTypeOfUserCookie);

                        // Выводим результат пользователю
                        response.setContentType("text/html");

                        out.println("<h1>Привет, пользователь!</h1>");
                        if (lastVisitCookie != null) {
                            out.println("<p>Ваш последний визит был " + lastVisitCookie.getValue() + "</p>");
                        }
                        out.println("<p>Вы посетили эту страницу " + visitCount + " раз</p>");
                        out.println("</body></html>");

                    }
                    /*else {
                        response.setContentType("text/html;charset=UTF-8");
                        PrintWriter out = response.getWriter();
                        out.println("<h1>Ошибка входа! </h1>");
                        out.println("<a href = 'ex3.jsp'>Вернуться обратно</a>");
                    }*/
                } catch (SQLException e) {
                    e.printStackTrace();
                }
            }
            else if(loggedIn != null && !loggedIn && "register".equals(action))
            {
                String sql2 = "insert users(username, password, typeOfUser)\n" +
                        "values\n" +
                        "(?, sha2(?, 256), 'user');";

                try(PreparedStatement statement = connection.prepareStatement(sql2))
                {
                    statement.setString(1,userLogin);
                    statement.setString(2,userPassword);
                    int rowsAffected = statement.executeUpdate();

                    if (rowsAffected > 0) {
                        PrintWriter out = response.getWriter();
                        out.println("<h1>Пользователь успешно прошёл регистрацию!</h1>");
                        out.println("<a href = 'ex3.jsp'>Вернуться обратно</a>");
                    }
                    else {
                        PrintWriter out = response.getWriter();
                        out.println("<h1>Пользователь c таким логином уже существует!!</h1>");
                        out.println("<a href = 'ex3.jsp'>Вернуться обратно</a>");
                    }
                }
                catch (SQLException e) {
                    e.printStackTrace();
                }
            }
            else if (loggedIn != null && !loggedIn && "login".equals(action))
            {
                // перенаправляем неавторизованных пользователей на страницу ex5.jsp
                ((HttpServletResponse) response).sendRedirect("ex5.jsp");
            }
        }

        catch (SQLException e) {
            e.printStackTrace();
        }

    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

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

    // Метод для получения объекта Cookie по имени из запроса
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
