package com.example.lab_13.Model;

public class infAboutProducts {
    public int id;

    public String name;
    public int count;
    public String city;

    public infAboutProducts(String name, int count, String city) {
        this.name = name;
        this.count = count;
        this.city = city;
    }

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

    public infAboutProducts(){}
}
