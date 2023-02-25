<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
</head>
<body>
<ul id="menu">
<?php
session_start();
    if(isset($_SESSION['user'])){
        echo "<li><a href='user.php?act=edit'>Edit profile</a></li><li><a href='user.php?act=logout'>Logout</a></li>";
    }
    else{
        echo "<li><a href='user.php?act=register'>Register</a></li><li><a href='user.php?act=login'>Login</a></li>";
    }
?>
</ul>
</body>
</html>
