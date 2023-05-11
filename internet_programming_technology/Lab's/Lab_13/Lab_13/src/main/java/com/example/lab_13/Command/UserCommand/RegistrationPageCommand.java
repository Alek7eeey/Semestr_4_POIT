package com.example.lab_13.Command.UserCommand;

import com.example.lab_13.Command.Command;
import com.example.lab_13.Command.CommandResult;
import com.example.lab_13.Pages.Page;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

public class RegistrationPageCommand implements Command {
    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response) {
        System.out.println("REGISTER_PAGE");
        return new CommandResult(Page.REGISTER_PAGE.getPage(), false);
    }
}
