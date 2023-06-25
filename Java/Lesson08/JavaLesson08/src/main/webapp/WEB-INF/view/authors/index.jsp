<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%@ page contentType="text/html;charset=UTF-8" isELIgnored="false" %>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Authors List</title>
    <link rel="stylesheet" href="https://unpkg.com/@picocss/pico@1.*/css/pico.min.css">
</head>
<body>
<h1>Authors List</h1>
<%@include file="../include/navigation.jsp"%>
<main>
    <table>
        <thead>
            <tr>
                <th>#</th>
                <th>Name</th>
                <th>Books</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
        <c:forEach var="author" items="${authors}">
            <tr>
                <td>${author.id}</td>
                <td>${author.firstName} ${author.lastName}</td>
                <td>
                    <c:forEach var="book" items="${author.publishedBooks}">
                        ${book.title}<br>
                    </c:forEach>
                </td>
                <td>
                    <a href="?delete=${author.id}">Delete</a>
                </td>
            </tr>
        </c:forEach>
        </tbody>
    </table>
</main>
</body>
</html>
