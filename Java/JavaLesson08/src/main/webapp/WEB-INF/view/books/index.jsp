<%--
  Created by IntelliJ IDEA.
  User: Yura
  Date: 26.02.2023
  Time: 12:42
  To change this template use File | Settings | File Templates.
--%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" isELIgnored="false" %>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Books List</title>
</head>
<body>
<h1>Books List</h1>
<nav>
    <menu>
        <li>
            <a href="/">Home Page</a>
        </li>
    </menu>
</nav>
<main>
    <table>
        <thead>
        <tr>
            <th>#</th>
            <th>Title</th>
            <th>Description</th>
            <th>Publish year</th>
            <th>Action</th>
        </tr>
        </thead>
        <c:forEach var="book" items="${books}">
            <tr>
                <td>${book.id}</td>
                <td>${book.title}</td>
                <td>${book.description}</td>
                <td>${book.publishYear}</td>
                <td>
                    <a href="?delete=${book.id}">Delete</a>
                </td>
            </tr>
        </c:forEach>
    </table>
</main>
</body>
</html>