package com.example.lab10;

import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;
@WebServlet(name = "ServletLogin", value = "/ServletLogin")
public class ServletLogin extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        List<MyData> myDataList = new ArrayList<MyData>();
        String userLogin = request.getParameter("userLogin");

        // устанавливаем атрибут в сессию
        HttpSession session = ((HttpServletRequest) request).getSession();
        Boolean loggedIn = (Boolean) session.getAttribute("loggedIn");
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();

        if(loggedIn != null && loggedIn)
        {
            response.setContentType("text/html;charset=UTF-8");
            String connectionString = "jdbc:mysql://localhost:3306/football_teams?autoReconnect=true&useSSL=false";
            try {
                Class.forName("com.mysql.cj.jdbc.Driver");
            }
            catch (ClassNotFoundException e) {
                throw new RuntimeException(e);
            }

            try (Connection connection = DriverManager.getConnection(connectionString, "root", "Kravchenko1")) {
                request.setCharacterEncoding("UTF-8");
                response.setContentType("text/html; charset=UTF-8");

                Statement stmt = connection.createStatement();
                String sql2 = "select f.id, f.name, f.countOfPlayers, f.city from \n" +
                        "user u inner join footballTeams f \n" +
                        "on u.id = f.userID\n" +
                        "where u.id = "+ Integer.toString(MyData.ThisID) + ";";

                try (ResultSet rs = stmt.executeQuery(sql2)) {
                    while (rs.next()) {
                       MyData myData = new MyData();
                        myData.setId(rs.getInt("id"));
                        myData.setName(rs.getString("name"));
                        myData.setCity(rs.getString("city"));
                        myData.setCount(rs.getInt("countOfPlayers"));
                        myDataList.add(myData);

                       /* information.add(Integer.toString(rs.getInt(1)) +"-----"+ rs.getString(2) +
                                "------" + Integer.toString(rs.getInt(3)) + "-------" + rs.getString(4));*/
                    }
                    rs.close();
                    stmt.close();
                    connection.close();


                }
                catch (SQLException e) {
                    e.printStackTrace();
                }
            }
            catch (SQLException e) {
                throw new RuntimeException(e);
            }

            request.setAttribute("myDataList", myDataList);
            request.setAttribute("name", MyData.ThisName);
            getServletContext().getRequestDispatcher("/welcome.jsp").forward(request, response);

        }

        else
        {
            response.sendRedirect("index.jsp?error=true");
        }
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {

    }
}
