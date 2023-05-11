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

import java.io.IOException;
import java.util.List;

public class RegistrNewUserCommand implements Command {
    private CommandResult registerError(HttpServletRequest request, String Error, String ERROR_MESSAGE)
    {
        request.setAttribute(Error, ERROR_MESSAGE);
        return new CommandResult(Page.REGISTER_PAGE.getPage(), false);
    }
    private CommandResult register(HttpServletRequest request)
    {
        return new CommandResult(Page.WELCOME_PAGE.getPage(), false);
    }

    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String userLogin = request.getParameter("userLogin");
        String userPassword = request.getParameter("userPassword");
        InfAboutUser user = new InfAboutUser(userLogin,userPassword);
        List<infAboutProducts> pr;

        try {
            if(!PersonService.LogIn(user))
            {
                InfAboutUser user2 = new InfAboutUser(userLogin, userPassword);

                if (PersonService.addPerson(user2)) {
                    return register(request);
                } else {

                    return registerError(request, "Ошибка регистрации", "Что-то пошло не так...");
                }

            }
            else
            {
                return registerError(request,"Ошибка регистрации", "Что-то пошло не так..." );
            }
        } catch (StandartException e) {
            throw new RuntimeException(e);
        }

    }
}
