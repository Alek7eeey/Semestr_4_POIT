package com.example.lab_13.Service;

import com.example.lab_13.DataBase.Repository.RepositoryUser;
import com.example.lab_13.Exceptions.ExceptionSQL;
import com.example.lab_13.Exceptions.StandartException;
import com.example.lab_13.Model.InfAboutUser;

public class PersonService {
    public static boolean addPerson(InfAboutUser user)
    {
        try
        {
            RepositoryUser.AddUserToDb(user.login, user.password);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static boolean LogIn(InfAboutUser user) throws StandartException {
        try {
            if(RepositoryUser.LogInUser(user.login, user.password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new StandartException("Ошибка при обращении к БД", ex);
        }
    }

}
