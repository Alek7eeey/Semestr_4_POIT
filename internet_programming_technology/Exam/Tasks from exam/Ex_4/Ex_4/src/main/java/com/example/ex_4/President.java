package com.example.ex_4;

public class President {
    public String name;
    public double golos;

    public String getName() {
        return name;
    }

    public double getGolos() {
        return golos;
    }

    public President(String name, double golos) {
        this.name = name;
        this.golos = golos;
    }

    public President() {
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setGolos(double golos) {
        this.golos = golos;
    }
}
