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
<?php
session_start();
$alert='';
if(isset($_SESSION['number'])){
    $number = $_SESSION['number'];
}
else{
    $number = random_int(1,100);
    $_SESSION['number'] = $number;
}

if($_SERVER['REQUEST_METHOD'] === 'POST'){
    $userNumber = $_POST['number'];
    if($userNumber > $number) $alert = "Number is big";
    if($userNumber < $number) $alert = "Number is small";
    if($userNumber == $number) {
        $alert = "You Win!!!";
        session_destroy();
    }
}
echo $alert;
?>
<form method="post">
    <label for="number">Enter you number</label>
    <input type="number" id="number" name="number">
    <input type="submit" value="Send">
</form>
</body>
</html>
