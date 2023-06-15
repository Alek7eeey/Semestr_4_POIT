<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>indexExam</title>
</head>
<body style="background-color: bisque">
    <form action="Servlet" style="border: solid black 2px; padding: 5px; box-shadow: cadetblue 1px 2px">
        <p><input type="text" name="id" placeholder="Введите id" maxlength="30" required style="box-shadow: aquamarine 3px 1px"/></p>
         <p>
            <button type="submit" name="action" value="login" style="box-shadow: blueviolet 2px 1px">Check</button>
        </p>
    </form>
</body>
</html>