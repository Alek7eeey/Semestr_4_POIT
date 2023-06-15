<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>Голосование</title>
</head>
<body>
    <h1>Online-голосование</h1>
    <form action="Servlet">
        <div>
        <label>
            <input type="radio" name="golos" value="bab">
            Бабарико
        </label>

        <label>
            <input type="radio" name="golos" value="cep">
            Цепкало
        </label>

        <label>
            <input type="radio" name="golos" value="tih">
            Тихановская
        </label>

        <label>
            <input type="radio" name="golos" value="dmi">
            Дмитриев
        </label>

        <button type="submit" name="action">Отправить</button>
        </div>
    </form>
</body>
</html>