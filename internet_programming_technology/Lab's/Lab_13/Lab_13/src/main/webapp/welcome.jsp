<%--
  Created by IntelliJ IDEA.
  User: aleks
  Date: 10.04.2023
  Time: 20:07
  To change this template use File | Settings | File Templates.
--%>
<%
  String name = "Tom";
%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<html>
<head>
  <title>Welcome page</title>
  <link rel="stylesheet" href="Style\wel.css">
</head>
<body>
<jsp:include page="header.jsp"/>

<h3>Добрый день, ${name}</h3>
<div class="wrapper">

  <div class="table">
    <table>
      <tr>
        <th>ID</th>
        <th>Название клуба</th>
        <th>Количество игроков</th>
        <th>Город</th>
      </tr>
      <c:forEach items="${myDataList}" var="myData">
        <tr>
          <td>${myData.id}</td>
          <td>${myData.name}</td>
          <td>${myData.count}</td>
          <td>${myData.city}</td>
        </tr>
      </c:forEach>
    </table>
  </div>

  <div class="addTeam">
    <% if (request.getParameter("error3") != null && request.getParameter("error3").equals("true")) { %>
    <p style="color: red; margin: 0">Ошибка добавления</p>
    <% } %>
    <form action="${pageContext.servletContext.contextPath}/Controller?command=add_new_person" method="post">
      <input type="text" name="name" placeholder="Название команды" required>
      <input type="text" name="count" placeholder="Количество игроков" required>
      <input type="text" name="city" placeholder="Город" required>
      <input type="submit" name="btn2" value="Добавить">
    </form>
  </div>

  <div class="addTeam">
    <% if (request.getParameter("error4") != null && request.getParameter("error4").equals("true")) { %>
    <p style="color: red; margin: 0">Ошибка удаления</p>
    <% } %>
    <form action="${pageContext.servletContext.contextPath}/Controller?command=remove" method="post">
      <input type="text" name="name" placeholder="Название команды" required>
      <input type="submit" name="btn2" value="Удалить">
    </form>
  </div>

</div>

</body>
</html>
