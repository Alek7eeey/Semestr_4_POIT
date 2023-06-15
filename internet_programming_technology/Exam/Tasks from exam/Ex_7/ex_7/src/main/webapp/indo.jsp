<%--
  Created by IntelliJ IDEA.
  User: aleks
  Date: 07.06.2023
  Time: 19:38
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
        <th>Дата</th>
        <th>Сумма</th>
    </tr>
    <c:forEach var="el" items="${lst}" varStatus="status">
        <tr>
            <td><c:out value="${el.year}"/></td>
            <td><c:out value="${el.sum}"/></td>
        </tr>
    </c:forEach>
</table>

<h2>Результирующая сумма: ${sum}</h2>
</body>
</html>
