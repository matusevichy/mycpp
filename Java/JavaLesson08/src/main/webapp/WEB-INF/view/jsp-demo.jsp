<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8"
         isELIgnored="false" %>
<html>
<head>
    <title>Jsp Demo</title>
</head>
<body>
<h1>Jsp Demo</h1>
<ul>
<%--    <%--%>
<%--        for (int i = 0; i < 10; i++) {--%>
<%--            out.println("<li> item " + i + "</li>");--%>
<%--        }--%>
<%--    %>--%>
    <c:forEach begin="0" end="9" var="i">
        <li>item ${i}</li>
    </c:forEach>
</ul>
<c:if test="${data == null}">
    <p>Data is not present</p>
</c:if>
<ul>
<c:forEach items="${data}" var="item">
    <li>${item}</li>
</c:forEach>
</ul>
</body>
</html>
