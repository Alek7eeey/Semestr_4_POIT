<%--
  Created by IntelliJ IDEA.
  User: aleks
  Date: 10.04.2023
  Time: 20:07
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
  <title>Register</title>
  <link rel="stylesheet" href="Style\index.css">
</head>
<body>
<jsp:include page="header.jsp"/>

<div class="wrapper" style="width: 300px; height: 250px">
  <% if (request.getParameter("error2") != null && request.getParameter("error2").equals("true")) { %>
  <p style="color: red; margin: 0">Ошибка регистрации</p>
  <% } %>
  <div>
    <div class="name"><h2>Регистрация нового пользователя</h2></div>
  </div>

  <form class="form" action="${pageContext.servletContext.contextPath}/Controller?command=register" method="post">
    <input type="text" placeholder="Введите логин" name="userLogin"size="18" maxlength="30" required>
    <input type="password" placeholder="Введите пароль" name="userPassword"size="18" maxlength="30" required>
    <input type="submit" class="btn" name="buttonRegister" value="Зарегистрироваться">
  </form>
</div>
</body>
</html>
