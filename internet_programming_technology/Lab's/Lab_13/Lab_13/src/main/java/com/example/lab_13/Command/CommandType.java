package com.example.lab_13.Command;

public enum CommandType {
    LOGIN("login"),
    ADD_NEW_PERSON("add_new_person"),
    REGISTER("register"),
    REMOVE("remove"),
    LOGIN_PAGE("login_page"),
    REGISTRATION_PAGE("registration_page");
    private String command;
    private CommandType(String com)
    {
        command = com;
    }
}
