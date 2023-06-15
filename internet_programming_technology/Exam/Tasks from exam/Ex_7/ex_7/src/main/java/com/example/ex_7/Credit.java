package com.example.ex_7;

public class Credit {

    public int year;
    public int sum;

    public Credit()
    {}

    public Credit(int year, int sum) {
        this.year = year;
        this.sum = sum;
    }

    public void setYear(int year) {
        this.year = year;
    }

    public void setSum(int sum) {
        this.sum = sum;
    }

    public int getYear() {
        return year;
    }

    public int getSum() {
        return sum;
    }
}
