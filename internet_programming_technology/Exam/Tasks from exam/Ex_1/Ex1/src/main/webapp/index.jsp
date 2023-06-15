<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>Main page</title>
</head>
<body>

    <form action="servlet1">
        <input type="text" placeholder="Введите логин" name="userLogin" maxlength="30" required>
        <input type="password" placeholder="Введите пароль" name="userPassword" maxlength="30" required>
        <Button type="submit" class="btn" name="buttonRegister">Войти</Button>
    </form>
</body>
</html>