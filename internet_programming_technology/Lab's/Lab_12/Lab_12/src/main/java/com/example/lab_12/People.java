package com.example.lab_12;

public class People {
    public String name;
    public int age;
    public char pol;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public char getPol() {
        return pol;
    }

    public void setPol(char pol) {
        this.pol = pol;
    }

    public People(String name, int age, char pol) {
        this.name = name;
        this.age = age;
        this.pol = pol;
    }

    public People(){}
}
