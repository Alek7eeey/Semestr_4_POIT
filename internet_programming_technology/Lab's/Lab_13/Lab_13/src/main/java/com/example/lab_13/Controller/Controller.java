package com.example.lab_13.Controller;

import com.example.lab_13.Command.Command;
import com.example.lab_13.Command.CommandFactory;
import com.example.lab_13.Command.CommandResult;
import com.example.lab_13.DataBase.Connection.ConnectionPool;
import com.example.lab_13.Model.MyData;
import com.example.lab_13.Pages.Page;
import jakarta.servlet.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;
import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;
import org.apache.log4j.xml.DOMConfigurator;

import java.io.IOException;
import java.sql.SQLException;
import java.time.LocalTime;

@WebServlet(name = "Controller", value = "/Controller")
public class Controller extends HttpServlet {
    private static final String COMMAND = "command";
    private static final String ERROR_MESSAGE = "error_message";

    @Override
    public void destroy()
    {
        try {
            ConnectionPool connectionPool = ConnectionPool.getInstance();
            connectionPool.destroy();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void init()
    {
        ConnectionPool.getInstance();
    }

    static {
        new DOMConfigurator().doConfigure("D:/studing/4_semestr/internet_programming_technology/Lab's/Lab_13/Lab_13/src/main/java/com/example/lab_13/log/log4j.xml", LogManager.getLoggerRepository());
    }
    private static final Logger LOG = Logger.getLogger(Controller.class);
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        MyData.isRegister = false;
        processRequest(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        processRequest(request,response);
    }

    private void processRequest(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        String command = request.getParameter(COMMAND);

        //Logger
        HttpServletRequest httpRequest = (HttpServletRequest) request;
        String servletPath = httpRequest.getServletPath();
        String method = httpRequest.getMethod();
        String timeStamp = LocalTime.now().toString();
        String remoteAddress = request.getRemoteAddr();

        LOG.info("Log: " +servletPath + method + timeStamp + remoteAddress + "Command:" + command);
        //end Logger

        Command action = CommandFactory.create(command);
        CommandResult commandResult;
        try {
            commandResult = action.execute(request, response);
        }
        catch (Exception ex)
        {
            request.setAttribute("name", ex.getMessage());
            commandResult = new CommandResult(Page.ERROR_PAGE.getPage(), false);
        }
        String page = commandResult.getPage();
        if(commandResult.isRedirect())
        {
            sendDirect(response, page);
        }
        else
        {
            dispatch(request, response, page);
        }
    }

    private void sendDirect(HttpServletResponse response, String page) throws IOException {
        response.sendRedirect(page);
    }

    private void dispatch(HttpServletRequest request, HttpServletResponse response, String page) throws ServletException, IOException {
        ServletContext servletContext = getServletContext();
        RequestDispatcher requestDispatcher = servletContext.getRequestDispatcher(page);
        requestDispatcher.forward(request, response);
    }
}
