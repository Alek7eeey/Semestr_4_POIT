package com.example.lab_13.Command.UserCommand;

import com.example.lab_13.Command.Command;
import com.example.lab_13.Command.CommandResult;
import com.example.lab_13.Exceptions.StandartException;
import com.example.lab_13.Model.InfAboutUser;
import com.example.lab_13.Model.MyData;
import com.example.lab_13.Model.infAboutProducts;
import com.example.lab_13.Pages.Page;
import com.example.lab_13.Service.PersonService;
import com.example.lab_13.Service.ProductsService;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import org.testng.annotations.*;

import java.io.IOException;
import java.sql.SQLException;
import java.util.List;

import static org.testng.Assert.assertFalse;
import static org.testng.Assert.assertTrue;

public class LoginCommand implements Command {
    String HI;

    private CommandResult loginError(HttpServletRequest request, String Error, String ERROR_MESSAGE)
    {
        request.setAttribute(Error, ERROR_MESSAGE);
        return new CommandResult(Page.LOGIN_PAGE.getPage(), false);
    }

    private CommandResult login(HttpServletRequest request)
    {
        return new CommandResult(Page.WELCOME_PAGE.getPage(), false);
    }
    @AfterSuite
    public void end()
    {
        System.out.println("Тест закончен!");
    }

    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response) throws IOException, SQLException, StandartException {
        String userLogin = request.getParameter("userLogin");
        String userPassword = request.getParameter("userPassword");
        InfAboutUser user = new InfAboutUser(userLogin,userPassword);
        List<infAboutProducts> pr;
        try {
            if(PersonService.LogIn(user))
            {
                pr = ProductsService.GetProducts();
                request.setAttribute("myDataList", pr);
                request.setAttribute("name", MyData.ThisName);
                assertFalse(pr.isEmpty());
                return login(request);
            }
            else
            {
                return loginError(request,"Ошибка регистрации", "Что-то пошло не так..." );
            }
        } catch (StandartException e) {
            throw new RuntimeException(e);
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }

        /*String userLogin = request.getParameter("userLogin");
        String userPassword = request.getParameter("userPassword");
        InfAboutUser user = new InfAboutUser(userLogin, userPassword);

        if(PersonService.LogIn(user))
        {
            return login(request);
        }
        else {
            return loginError(request,"Ошибка регистрации", "Что-то пошло не так..." );
        }*/
    }
}
