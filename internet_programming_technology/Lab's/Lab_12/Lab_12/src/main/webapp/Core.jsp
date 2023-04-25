<%--
  Created by IntelliJ IDEA.
  User: aleks
  Date: 23.04.2023
  Time: 15:23
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<html>
<head>
    <title>Core</title>
    <link  rel="stylesheet" href="Core.css"/>
</head>
<body>
    <c:set var = "user" value="guest" scope="page"/>
    <c:if test="${not empty user and user eq 'guest'}">
       <c:out value = " Variable = ${user}"/>
    </c:if>

    <br>
    <c:set var = "user" scope="page">
        Guest
    </c:set>
    <c:out value="Variable = ${user}"/>

    <br>
    <c:set var = "num" value="55" scope="page"/>
    <c:choose>
        <c:when test="${num < 50}">
            <c:out value="Значение меньше 50"/>
        </c:when>
        <c:when test="${num > 50}">
            <c:out value="Значение больше 50"/>
        </c:when>
    </c:choose>

    <br>
    <c:set var = "numDouble" value="7.32" scope="page"/>
    <c:catch var = "formatExc">
        <c:if test="${numDouble<9}">
            <c:out value="Number = ${numDouble} меньше 9"/>
        </c:if>
    </c:catch>
    <br/>
    <hr/>
    <c:if test="${not empty formatExc}">
        <c:out value="Неверный тип: ${numDouble}"/>
        <p style="color: red">Сгенерировано исключение</p>
        ${formatExc}
    </c:if>
    <hr/>

    <table>
        <tr>
            <th>Имя</th>
            <th>Возраст</th>
            <th>Пол</th>
        </tr>
        <c:forEach var="el" items="${lst}" varStatus="status">
        <tr>
            <td><c:out value="${el.name}"/></td>
            <td><c:out value="${el.age}"/></td>
            <td><c:out value="${el.pol}"/></td>
        </tr>
        </c:forEach>
    </table>

    <hr/>
    <c:set var="str" value="1. 2 \ 3 - 4 5"/>
        <c:forTokens var="token" items="${str}" delims=".\-">
            <c:out value="${token}"/><br/>
        </c:forTokens>

    <c:import url="ExampleInclude.jsp"/>
</body>
</html>
