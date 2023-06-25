<%@ page contentType="text/html;charset=UTF-8" language="java"
         isELIgnored="false" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<h1>Main page</h1>
<p>Local time: ${currentTime}</p>
<h2>Hello ${user.firstName}</h2>
<form method="post">
    <div>
    <label for="firstName">First Name</label>
    <input type="text" name="firstName" id="firstName" />
    </div>
    <div>
        <label for="lastName">Last Name</label>
        <input type="text" name="lastName" id="lastName" />
    </div>
    <button type="submit">Greeting</button>
</form>
</body>
</html>
