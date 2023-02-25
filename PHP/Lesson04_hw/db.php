<?php
include_once 'configurations/dbconfig.php';


try {
    $pdo = new PDO("mysql:host=$dbHost; dbname=$dbName",DBUSER, DBPASS);
}
catch (PDOException $e){
    echo $e->getMessage();
}

