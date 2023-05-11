<%--
  Created by IntelliJ IDEA.
  User: aleks
  Date: 10.05.2023
  Time: 13:07
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Header</title>
  <link rel="stylesheet" href="Style\header.css">
</head>
<body>
<div class="wrap">
  <div style="width: 100%; background-color: #ffe2b8; margin-bottom: 15px; display: flex; flex-direction: column">
    <div>
      <ul>
        <li><a href="${pageContext.request.contextPath}/Controller?command=login_page">Авторизация</a></li>
        <li><a href="${pageContext.request.contextPath}/Controller?command=registration_page">Регистрация</a></li>
      </ul>
    </div>
  </div>
</div>
</body>
</html>
