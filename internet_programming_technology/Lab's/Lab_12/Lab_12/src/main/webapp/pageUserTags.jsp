<%--
  Created by IntelliJ IDEA.
  User: aleks
  Date: 25.04.2023
  Time: 8:41
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib prefix = "ex" uri = "userTags" %>
<html>
<head>
    <title>UserTags</title>
    <link rel="stylesheet" href="Core.css">
</head>
<body>
    <ex:KadSubmit/>
    <br/>
    <div style="margin-top: 20px">
        <ex:KadPrintTable nameTable="users" nameDB="Java"/>
    </div>
</body>
</html>
