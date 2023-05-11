package com.example.lab_13.Model;

public class InfAboutUser {
    public int id;
    public String login;
    public String password;

    public void setLogin(String login) {
        this.login = login;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public int getId() {
        return id;
    }

    public String getLogin() {
        return login;
    }

    public String getPassword() {
        return password;
    }

    public void setId(int id) {
        this.id = id;
    }

    public InfAboutUser(int id) {
        this.id = id;
    }

    public InfAboutUser(String login, String password) {
        this.login = login;
        this.password = password;
    }
}
