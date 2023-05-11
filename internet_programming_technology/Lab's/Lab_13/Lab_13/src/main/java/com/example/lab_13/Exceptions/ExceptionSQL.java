package com.example.lab_13.Exceptions;

import java.sql.SQLException;

public class ExceptionSQL extends SQLException {
    public ExceptionSQL(String message)
    {
        super(message);
    }

    public ExceptionSQL(String message, Throwable cause)
    {
        super(message, cause);
    }
}
