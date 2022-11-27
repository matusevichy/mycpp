<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Request handling</title>
</head>
<body>
<nav>
    <menu>
        <li><a href="index.php">home</a></li>
        <li><a href="files.php">files</a></li>
        <li><a href="serialization.php">serialization</a></li>
    </menu>
</nav>
<form method="post">
    <fieldset>
        <legend>Student form</legend>
        <div>
            <label for="first-name">First Name</label>
            <input name="first-name" id="first-name" required="required"/>
        </div>
        <div>
            <label for="last-name">Last Name</label>
            <input name="last-name" id="last-name" required="required"/>
        </div>
        <div>
            <label for="birthdate">Birthdate</label>
            <input name="birthdate" id="birthdate" type="date" required="required"/>
        </div>
    </fieldset>
    <input type="submit"/>
</form>

<?php
$file_name="DB/students.db";
//echo '<pre>';
//print_r($_POST);
//echo '</pre>';
//echo '<pre>';
//print_r($_SERVER);
//echo '</pre>';
$arr=[];
if (file_exists($file_name)){
    $data = file_get_contents($file_name);
    $arr=unserialize($data);
    }
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $first_name = $_POST['first-name'];
    $last_name = $_POST['last-name'];
    $birthdate = $_POST['birthdate'];
    if (is_array($arr)){
        array_push($arr, [$first_name, $last_name, $birthdate]);
    }
    else{
        $arr=[0=>[$first_name, $last_name, $birthdate]];
    }
    file_put_contents($file_name, serialize($arr));
}
    echo "<table><thead><tr><td>First name</td><td>Last name</td><td>Birthdate</td></tr></thead><tbody>";
    foreach ($arr as $key=>$value) {
        echo "<tr>";
        foreach ($value as $tk=>$tv)
        {
            echo "<td>$tv</td>";
        }
        echo "</tr>";
    }
    echo "</tbody></table>";
?>
</body>
</html>


