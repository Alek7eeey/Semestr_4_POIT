<%--
  Created by IntelliJ IDEA.
  User: aleks
  Date: 07.06.2023
  Time: 15:31
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Look</title>
</head>
<body>
    <p>${name}</p>
    <form action="Servlet2">
        <button type="submit" name="Like">Like</button>
    </form>

    <form action="Servlet3">
        <button type="submit" name="Dislike">Dislike</button>
    </form>
</body>
</html>
