<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" isELIgnored="false" %>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Books List</title>
    <link rel="stylesheet" href="https://unpkg.com/@picocss/pico@1.*/css/pico.min.css">
</head>
<body>
<h1>Books List</h1>
<%@include file="../include/navigation.jsp"%>
<main>
    <table>
        <thead>
        <tr>
            <th>#</th>
            <th>Title</th>
            <th>Description</th>
            <th>Publisher</th>
            <th>Authors</th>
            <th>Action</th>
        </tr>
        </thead>
        <c:forEach var="book" items="${books}">
            <tr>
                <td>${book.id}</td>
                <td>${book.title}</td>
                <td>${book.description.substring(0, 100)}</td>
                <td>${book.publisher.name}</td>
                <td>
                    <c:forEach var="author" items="${book.authors}">
                        ${author.firstName} ${author.lastName} <br>
                    </c:forEach>
                </td>
                <td>
                    <a href="?delete=${book.id}">Delete</a>
                </td>
            </tr>
        </c:forEach>
    </table>
</main>
</body>
</html>
