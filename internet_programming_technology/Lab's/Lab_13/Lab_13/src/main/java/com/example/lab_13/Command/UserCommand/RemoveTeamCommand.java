package com.example.lab_13.Command.UserCommand;

import com.example.lab_13.Command.Command;
import com.example.lab_13.Command.CommandResult;
import com.example.lab_13.Model.MyData;
import com.example.lab_13.Model.infAboutProducts;
import com.example.lab_13.Pages.Page;
import com.example.lab_13.Service.ProductsService;
import jakarta.servlet.RequestDispatcher;
import jakarta.servlet.ServletContext;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.sql.SQLException;
import java.util.List;

public class RemoveTeamCommand implements Command {
    private CommandResult RemoveTeamError(HttpServletRequest request, String Error, String ERROR_MESSAGE)
    {
        request.setAttribute(Error, ERROR_MESSAGE);
        return new CommandResult(Page.WELCOME_PAGE.getPage(), false);
    }
    private CommandResult removeTeam(HttpServletRequest request)
    {
        return new CommandResult(Page.WELCOME_PAGE.getPage(), false);
    }

    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response) throws SQLException {
        String name = request.getParameter("name");

        if(ProductsService.removeProduct(name))
        {
            List<infAboutProducts> productsList = ProductsService.GetProducts();
            request.setAttribute("myDataList", productsList);
            request.setAttribute("name", MyData.ThisName);
            return removeTeam(request);
        }
        else
        {
            request.setAttribute("name", "Нет такой команды для удаления");
            return RemoveTeamError(request, "Ошибка удаления","Что-то пошло не так...");
        }
    }
}
