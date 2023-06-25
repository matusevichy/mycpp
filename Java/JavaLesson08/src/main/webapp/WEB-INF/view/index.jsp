<%@page isELIgnored="false" %>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>
        ${title}
    </title>
    <link rel="stylesheet" href="https://unpkg.com/@picocss/pico@1.*/css/pico.min.css">
</head>
<body>
<h1>
    <%= request.getAttribute("title") %>
</h1>
<nav>
    <menu>
        <li>
            <a href="/publishers">Publishers</a>
        </li>
        <li>
            <a href="/books">Books</a>
        </li>
    </menu>
</nav>

</body>
</html>
