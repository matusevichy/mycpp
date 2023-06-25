<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" isELIgnored="false" %>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Publishers List</title>
    <link rel="stylesheet" href="https://unpkg.com/@picocss/pico@1.*/css/pico.min.css">
</head>
<body>
<h1>Publishers List</h1>
<%@include file="../include/navigation.jsp"%>
<main>
    <table>
        <thead>
        <tr>
            <th>#</th>
            <th>Name</th>
            <th>Publish books</th>
            <th>Action</th>
        </tr>
        </thead>
        <c:forEach var="publisher" items="${publishers}">
            <tr>
                <td>${publisher.id}</td>
                <td>${publisher.name}</td>
                <td>${publisher.books.size()}</td>
                <td>
                    <a href="?delete=${publisher.id}">Delete</a>
                </td>
            </tr>
        </c:forEach>
    </table>
</main>
</body>
</html>
