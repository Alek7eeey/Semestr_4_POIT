package com.example.lab_13.Command;

import com.example.lab_13.Command.UserCommand.*;

public class CommandFactory {
    public static Command create(String command)
    {
        command = command.toUpperCase();
        System.out.println(command);
        CommandType commandEnum = CommandType.valueOf(command);
        Command resultCommand = new LoginCommand();

        switch (commandEnum)
        {
            case LOGIN:
                resultCommand = new LoginCommand();
                break;
            case REGISTER:
                resultCommand = new RegistrNewUserCommand();
                break;
            case REMOVE:
                resultCommand = new RemoveTeamCommand();
                break;
            case ADD_NEW_PERSON:
                resultCommand = new AddTeamCommand();
                break;
            case LOGIN_PAGE:
                resultCommand = new LoginPageCommand();
                break;
            case REGISTRATION_PAGE:
                resultCommand = new RegistrationPageCommand();
                break;
            default:{
                throw new IllegalArgumentException("Invalid command: " + commandEnum);
            }
        }
        return resultCommand;
    }
}
