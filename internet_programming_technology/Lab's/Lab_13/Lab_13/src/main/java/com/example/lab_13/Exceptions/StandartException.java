package com.example.lab_13.Exceptions;

public class StandartException extends Exception{
    public StandartException(String message)
    {
        super(message);
    }

    public StandartException(String message, Throwable cause)
    {
        super(message, cause);
    }
}
