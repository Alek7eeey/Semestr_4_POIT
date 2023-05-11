package com.example.lab_13.Command.UserCommand;

import com.example.lab_13.Command.Command;
import com.example.lab_13.Command.CommandResult;
import com.example.lab_13.Model.InfAboutUser;
import com.example.lab_13.Model.MyData;
import com.example.lab_13.Model.infAboutProducts;
import com.example.lab_13.Pages.Page;
import com.example.lab_13.Service.PersonService;
import com.example.lab_13.Service.ProductsService;
import jakarta.servlet.RequestDispatcher;
import jakarta.servlet.ServletContext;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.sql.SQLException;
import java.util.List;

public class AddTeamCommand implements Command {
    private CommandResult addTeamError(HttpServletRequest request, String Error, String ERROR_MESSAGE)
    {
        request.setAttribute(Error, ERROR_MESSAGE);
        return new CommandResult(Page.WELCOME_PAGE.getPage(), false);
    }
    private CommandResult addTeam(HttpServletRequest request)
    {
        return new CommandResult(Page.WELCOME_PAGE.getPage(), false);
    }

    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response) throws SQLException {

        String name = request.getParameter("name");
        int count = Integer.parseInt(request.getParameter("count"));
        String city = request.getParameter("city");

        infAboutProducts product = new infAboutProducts(name, count, city);

        if(ProductsService.AddProduct(product))
        {
            List<infAboutProducts> productsList = ProductsService.GetProducts();
            request.setAttribute("myDataList", productsList);
            request.setAttribute("name", MyData.ThisName);
            return addTeam(request);
        }
        else {
            request.setAttribute("name", "Ошибка при добавлении");
            return addTeamError(request,"Ошибка регистрации", "Что-то пошло не так..." );
        }
    }
}
