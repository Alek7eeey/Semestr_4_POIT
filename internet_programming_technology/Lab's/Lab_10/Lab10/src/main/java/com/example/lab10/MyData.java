package com.example.lab10;

public class MyData
{

    public static int ThisID;
    public static String ThisName;
    public static boolean isRegister = false;
    public int id;

    public String name;
    public int count;
    public String city;

    public void setId(int id) {
        this.id = id;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public int getCount() {
        return count;
    }

    public String getCity() {
        return city;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setCount(int count) {
        this.count = count;
    }

    public void setCity(String city) {
        this.city = city;
    }
}
