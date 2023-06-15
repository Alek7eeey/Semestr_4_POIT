<%--
  Created by IntelliJ IDEA.
  User: aleks
  Date: 06.06.2023
  Time: 23:03
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<html>
<head>
    <title>Info</title>
</head>
<body>
<table>
  <tr>
    <th>Имя</th>
    <th>Количество голосов</th>
  </tr>
  <c:forEach var="el" items="${lst}" varStatus="status">
    <tr>
      <td><c:out value="${el.name}"/></td>
      <td><c:out value="${el.golos}"/></td>
    </tr>
  </c:forEach>
</table>
</body>
</html>
