package com.example.lab_13.Command.UserCommand;

import com.example.lab_13.Command.Command;
import com.example.lab_13.Command.CommandResult;
import com.example.lab_13.Pages.Page;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

public class LoginPageCommand implements Command {
    @Override
    public CommandResult execute(HttpServletRequest request, HttpServletResponse response) {
        return new CommandResult(Page.LOGIN_PAGE.getPage(), false);
    }
}
