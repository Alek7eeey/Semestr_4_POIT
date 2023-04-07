<%--
  Created by IntelliJ IDEA.
  User: aleks
  Date: 05.04.2023
  Time: 22:45
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
  <title>Title</title>
</head>
<body>
<div class="registration" style="display: flex; flex-direction: column">
  <form action="Servlet2">
    <p><input type="text" name="userLogin" placeholder="Введите логин" size="18" maxlength="30" required/></p>
    <p><input type="password" name="userPassword" placeholder="Введите пароль" size="18" maxlength="30" required/></p>
    <p>
      <button type="submit" name="action" value="login">Отправить</button>
    </p>
  </form>
</div>
</body>
</html>
