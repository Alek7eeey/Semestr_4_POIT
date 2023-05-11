package com.example.lab_13.Pages;

public enum Page
{
    LOGIN_PAGE("/index.jsp"),
    REGISTER_PAGE("/register.jsp"),
    WELCOME_PAGE("/welcome.jsp"),
    ERROR_PAGE("/errorPage.jsp");

    private final String thisStr;
    Page(String s) {
        thisStr = s;
    }

    public String getPage()
    {
        return thisStr;
    }
}