<%@ page import="java.io.PrintWriter" %>
<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>Log in</title>
    <link rel="stylesheet" href="Style\index.css">
</head>
<body>
<jsp:include page="header.jsp"/>
<div class="wrapper" style="width: 300px; height: 250px">

    <% if (request.getParameter("error") != null && request.getParameter("error").equals("true")) { %>
    <p style="color: red; margin: 0">Ошибка авторизации</p>
    <% } %>

    <div>
        <div class="name"><h2>Авторизация</h2></div>
    </div>

    <form class="form" action="${pageContext.servletContext.contextPath}/Controller?command=login" method="post">
        <input type="text" placeholder="Введите логин" name="userLogin" size="18" maxlength="30" required>
        <input type="password" placeholder="Введите пароль" name="userPassword" size="18" maxlength="30" required>
        <input type="submit" class="btn" name="buttonUser" value="Войти">
    </form>
</div>
</body>
</html>